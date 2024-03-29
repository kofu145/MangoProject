﻿using System.Numerics;
using MangoProject.Prefabs;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using GramEngine.Core.Input;
using MangoProject.Components.MovementBehavior;
using MangoProject.Events;
using MangoProject.Utils;

namespace MangoProject.Components;

public class Player: Component
{

    public int Health;
    private Sprite sprite;
    private PlayerBulletPrefab bullet;
    private bool isFiring;
    private float nextFireEvent;
    private float attackSpeed;
    private bool focusing;
    private Sprite focusSprite;
    private bool isInvincible;
    private float loseInvincibleEvent;
    private float invincibleDuration;
    private float flickerTime;
    private float flickerEvent;
    private Entity focusEntity;
    private int attackLevel;
    private int power;

    private Keys[] inputs = { Keys.Up, Keys.Down, Keys.Left, Keys.Right, Keys.Space, Keys.LShift };
    private float topSpeed;
    private float speed;
    private float focusSpeed;
    private Rigidbody rb;
    
    public Player(float speed, float focusSpeed, int health, float attackSpeed, float invincibleDuration, float flickerTime)
    {
        this.speed = speed;
        this.focusSpeed = focusSpeed;
        topSpeed = speed;
        Health = health;
        this.attackSpeed = attackSpeed;
        isFiring = false;
        nextFireEvent = 0;
        focusing = false;
        isInvincible = false;
        loseInvincibleEvent = 0;
        this.invincibleDuration = invincibleDuration;
        this.flickerTime = flickerTime;
        attackLevel = 1;
        this.power = 0;
        flickerEvent = 0;

    }

    public override void Initialize()
    {
        
        focusEntity = new Entity()
            .AddComponent(new Sprite("./Content/basic_bullet.png"))
            .AddComponent(new LockPosition(ParentEntity));
        focusEntity.Transform.Scale = new Vector2(2f, 2f);
        focusSprite = focusEntity.GetComponent<Sprite>();
        focusSprite.Enabled = false;
        ParentScene.AddEntity(focusEntity);

        sprite = ParentEntity.GetComponent<Sprite>();
        rb = ParentEntity.GetComponent<Rigidbody>();
        bullet = new PlayerBulletPrefab();
    }

    public override void Update(GameTime gameTime)
    {
        isFiring = false;
        focusSprite.Enabled = false;
        speed = topSpeed;
        
        CheckPoC();

        Vector3 direction = Vector3.Zero;

        if (InputManager.GetKeyPressed(inputs[0]))
            direction.Y = -1;

        if (InputManager.GetKeyPressed(inputs[1]))
            direction.Y = 1;

        if (InputManager.GetKeyPressed(inputs[2]))
            direction.X = -1;

        if (InputManager.GetKeyPressed(inputs[3]))
            direction.X = 1;

        if (InputManager.GetKeyPressed(inputs[4]))
            isFiring = true;

        if (InputManager.GetKeyPressed(inputs[5]))
        {
            speed = focusSpeed;
            focusSprite.Enabled = true;
        }

        if (isFiring && gameTime.TotalTime.TotalSeconds >= nextFireEvent)
        {
            ShootBullet(gameTime);

        }

        if (isInvincible && gameTime.TotalTime.TotalSeconds >= loseInvincibleEvent)
        {
            isInvincible = false;
            sprite.Enabled = true;
        }

        if (isInvincible && gameTime.TotalTime.TotalSeconds > flickerEvent)
        {
            sprite.Enabled = !sprite.Enabled;
            flickerEvent = (float)GameStateManager.GameTime.TotalTime.TotalSeconds + flickerTime;
        }

        if (direction != Vector3.Zero)
            direction = Vector3.Normalize(direction);
        rb.Velocity = direction * speed;

        float boundaryX = StageUtils.Width;
        float boundaryY = StageUtils.Height;
        
        Transform.Position.X = Math.Clamp(
            Transform.Position.X,
            (sprite.Width+.05f * Transform.Scale.X) / 2, 
            (boundaryX - ((sprite.Width-.05f * Transform.Scale.X) / 2)));
        
        Transform.Position.Y = Math.Clamp(
            Transform.Position.Y, 
            (sprite.Height * Transform.Scale.Y / 2), 
            boundaryY -(sprite.Height * Transform.Scale.Y / 2));

    }

    public void TakeDamage()
    {
        if (!isInvincible)
        {
            
            if (Health <= 0)
            {
                Console.WriteLine("Dead!");
            }

            isInvincible = true;
            loseInvincibleEvent = (float)GameStateManager.GameTime.TotalTime.TotalSeconds + invincibleDuration;
            flickerEvent = (float)GameStateManager.GameTime.TotalTime.TotalSeconds + flickerTime;
            Transform.Position = new Vector3(290, 600f, 0f);
            List<Entity> enemies = ParentScene.FindEntitiesWithTag("enemy");
            List<Entity> bullets = ParentScene.FindEntitiesWithTag("bullet");
            foreach (var entity in bullets)
            {
                ParentScene.DestroyEntity(entity);
            }

            foreach (var entity in enemies)
            {
                entity.GetComponent<Sound>().Stop();
            }
        }
    }

    public void AddPower(int amount)
    {
        power += amount;
        // flawed in case adding 800 or more
        if (power >= 100)
        {
            if (attackLevel < 3)
                attackLevel++;
            power = 0;

        }
    }

    public void CheckPoC()
    {
        if (Transform.Position.Y < 200)
        {
            var items = ParentScene.Entities.Where(e => e.Tag == "item");
            foreach (var item in items)
            {
                if (!item.HasComponent<HomingToEntity>())
                {
                    item.AddComponent(new HomingToEntity(ParentEntity, false, 400));
                }
            }
        }
    }

    public void ShootBullet(GameTime gameTime)
    {
        switch (attackLevel)
        {
            case 1:
                var playerBullet = bullet.Instantiate();
                MakeBullet(0, 0, -1300);
                nextFireEvent = (float)gameTime.TotalTime.TotalSeconds + attackSpeed;
                break;
            case 2:
                for (int i = 0; i < 3; i++)
                {
                    MakeBullet(-15 + i * 15, 0, -1300);
                    nextFireEvent = (float)gameTime.TotalTime.TotalSeconds + attackSpeed;
                }
                break;
            case 3:
                var velxMid = 10;
                for (int i = 0; i < 2; i++)
                {
                    velxMid *= -1;
                    MakeBullet(-10 + i * 20, velxMid, -1300);
                }

                var velx = 100;
                for (int i = 0; i < 2; i++)
                {
                    velx *= -1;
                    MakeBullet(-15 + i * 30, velx, -1250);
                }
                nextFireEvent = (float)gameTime.TotalTime.TotalSeconds + attackSpeed;
                break;
            case 4:
                
                
                var velxMidFour = 10;
                for (int i = 0; i < 2; i++)
                {
                    velxMidFour *= -1;
                    MakeBullet(-10 + i * 20, velxMidFour, -1300);
                }

                var velxFour = 100;
                for (int i = 0; i < 2; i++)
                {
                    velxFour *= -1;
                    MakeBullet(-15 + i * 30, velxFour, -1250);
                    nextFireEvent = (float)gameTime.TotalTime.TotalSeconds + attackSpeed;
                }
                
                break;
        }
        
    }

    public void MakeBullet(float xOffset, float velX, float velY)
    {
        var bull = bullet.Instantiate();
        bull.Transform.Position = Transform.Position;
        bull.Transform.Position.X += xOffset;
        bull.GetComponent<Rigidbody>().AddForce(new Vector3(velX, velY, 0));
        ParentScene.AddEntity(bull);
    }
    
}
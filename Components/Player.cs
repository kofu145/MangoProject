﻿using System.Numerics;
using EirTesting.Prefabs;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using GramEngine.Core.Input;
using MangoProject.Components.MovementBehavior;
using MangoProject.Utils;

namespace MangoProject.Components;

public class Player: Component
{

    public int Health;
    private Sprite sprite;
    private PlayerBullet bullet;
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

    private Keys[] inputs = { Keys.W, Keys.S, Keys.A, Keys.D, Keys.Space, Keys.LShift };
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
        var focusEntity = new Entity()
            .AddComponent(new Sprite("./Content/basic_bullet.png"))
            .AddComponent(new LockPosition(ParentEntity));
        focusSprite = focusEntity.GetComponent<Sprite>();
        focusSprite.Enabled = false;
        ParentScene.AddEntity(focusEntity);
        isInvincible = false;
        loseInvincibleEvent = 0;
        this.invincibleDuration = invincibleDuration;
        this.flickerTime = flickerTime;
        flickerEvent = 0;

    }

    public override void Initialize()
    {
        sprite = ParentEntity.GetComponent<Sprite>();
        rb = ParentEntity.GetComponent<Rigidbody>();
        bullet = new PlayerBullet();
    }

    public override void Update(GameTime gameTime)
    {
        isFiring = false;
        focusSprite.Enabled = false;
        speed = topSpeed;
        
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
            // bullet code
        }

        if (isInvincible && gameTime.TotalTime.TotalSeconds >= loseInvincibleEvent)
        {
            isInvincible = false;
            sprite.Enabled = true;
        }
        
        if (isInvincible && gameTime.TotalTime.TotalSeconds > flickerEvent)
            sprite.Enabled = !sprite.Enabled;

        if (direction != Vector3.Zero)
            direction = Vector3.Normalize(direction);
        rb.Velocity = direction * speed;

        float boundaryX = StageUtils.Width;
        float boundaryY = GameStateManager.Window.Height;
        
        Transform.Position.X = Math.Clamp(
            Transform.Position.X,
            (-boundaryX / 2 + ((sprite.Width+.05f * Transform.Scale.X) / 2)), 
            (boundaryX / 2- ((sprite.Width-.05f * Transform.Scale.X) / 2)));
        
        Transform.Position.Y = Math.Clamp(Transform.Position.Y, 
            -boundaryY / 2 + (sprite.Height * Transform.Scale.Y / 2), 
            boundaryY / 2 -(sprite.Height * Transform.Scale.Y / 2));

    }

    public void TakeDamage()
    {
        if (!isInvincible)
        {
            if (Health <= 0)
            {
                // death
            }

            isInvincible = true;
            loseInvincibleEvent = (float)
        }
    }
}
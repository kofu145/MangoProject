using System.Numerics;
using GramEngine.Core;
using GramEngine.Core.Input;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using MangoProject.Components;

namespace MangoProject.Scenes;

public class TestScene : GameState
{
    private Entity kitsuneEntity;
    public override void Initialize()
    {
        base.Initialize();
        
        kitsuneEntity = new Entity();
        kitsuneEntity.AddComponent(new Sprite("./Content/kitsune.png"));
        kitsuneEntity.Transform.Scale = new Vector2(3f, 3f);//, 0f);
        kitsuneEntity.Transform.Position.Z = 0;
        kitsuneEntity.AddComponent(new Player(400));
        kitsuneEntity.AddComponent(new Rigidbody());

        var bulletTexture = "./Content/smaller_bullet.png";
        var bulletSize = 2f;
        Random random = new Random();
        
        for (int i = 0; i<10000; i++)
        {
            var bullet1 = new Entity();
            bullet1.AddComponent(new Sprite(bulletTexture));
            var sprite = bullet1.GetComponent<Sprite>();

            bullet1.Transform.Scale = new Vector2(bulletSize, bulletSize);//, 2f);
            sprite.Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);
            bullet1.Transform.Position = new Vector3(random.Next(100, 1200), random.Next(50, 700), 5f);

            float angle = random.Next(0, 360);
            Vector3 direction = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0f);
            
            bullet1.AddComponent(new TestBullet());
            bullet1.AddComponent(new CircleCollider(sprite.Width / 2 * bulletSize, false, false));
            
            bullet1.AddComponent(new Rigidbody());
            var rb = bullet1.GetComponent<Rigidbody>();
            rb.AddForce(direction*300);
            AddEntity(bullet1);
        }
        kitsuneEntity.Transform.Position = new Vector3(100, 100, 20);
        //AddEntity(kitsuneEntity);
    }

    public override void Update(GameTime gameTime)
    {
        if (InputManager.GetKeyPressed(Keys.Space))
        {
            foreach (var entity in GameScene.Entities)
            {
                entity.Transform.Position = new Vector3(1280/2, 720/2, 0);
            }
        }
    }
}
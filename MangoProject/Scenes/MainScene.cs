using Easel.Entities;
using Easel.Graphics;
using Easel.Scenes;
using Easel;
using Easel.Graphics.Renderers;
using MangoProject.Components;
using System.Numerics;
using Easel.Entities.Components;

namespace MangoProject.Scenes;
public class MainScene : Scene
{
    private Entity kitsuneEntity;
    protected override void Initialize()
    {
        base.Initialize();
        
        Camera.Main.CameraType = CameraType.Orthographic;
        World.SpriteRenderMode = SpriteRenderMode.Nearest;
        kitsuneEntity = new Entity();
        kitsuneEntity.AddComponent(new Sprite(Content.Load<Texture2D>("kitsune.png")));
        kitsuneEntity.Transform.Scale = new Vector3(3f, 3f, 0f);
        kitsuneEntity.Transform.Position.Z = 0;
        kitsuneEntity.AddComponent(new Player(400f));
        kitsuneEntity.AddComponent(new Rigidbody());

        var bulletTexture = Content.Load<Texture2D>("smaller_bullet.png");
        var bulletSize = 2f;
        Random random = new Random();
        
        for (int i = 0; i<100; i++)
        {
            var bullet1 = new Entity();
            bullet1.AddComponent(new Sprite(bulletTexture));
            bullet1.Transform.Scale = new Vector3(bulletSize, bulletSize, 2f);
            bullet1.Transform.Origin = new Vector3(bulletTexture.Size.Width / 2, bulletTexture.Size.Height / 2, 1);
            bullet1.Transform.Position = new Vector3(random.Next(100, 1200), random.Next(50, 700), 5f);

            float angle = random.Next(0, 360);
            Vector3 direction = new Vector3((float)Math.Cos(angle), (float)Math.Sin(angle), 0f);
            
            bullet1.AddComponent(new TestBullet());
            bullet1.AddComponent(new CircleCollider(bulletTexture.Size.Width / 2 * bulletSize, false));
            
            bullet1.AddComponent(new Rigidbody());
            bullet1.GetComponent<Rigidbody>().AddForce(direction*300);
            AddEntity(bullet1);
        }

        AddEntity(kitsuneEntity);
    }

    protected override void Update()
    {
        base.Update();
        
    }
}

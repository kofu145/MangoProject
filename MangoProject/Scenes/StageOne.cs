using Easel.Entities;
using Easel.Graphics;
using Easel.Scenes;
using Easel;
using Easel.Graphics.Renderers;
using MangoProject.Components;
using System.Numerics;
using Easel.Entities.Components;
using Pie;

namespace MangoProject.Scenes;

public class StageOne : Scene
{
    private Entity kitsuneEntity;
    protected override void Initialize()
    {
        base.Initialize();

        Camera.Main.CameraType = CameraType.Orthographic;
        World.SpriteRenderMode = SpriteRenderMode.Nearest;
        kitsuneEntity = new Entity();
        Texture2D kitsuneTexture = Content.Load<Texture2D>("kitsune.png");
        kitsuneEntity.AddComponent(new Sprite(kitsuneTexture));
        kitsuneEntity.Transform.Scale = new Vector3(3f, 3f, 0f);
        kitsuneEntity.Transform.Origin = new Vector3(kitsuneTexture.Size.Width / 2, kitsuneTexture.Size.Height / 2, 1);
        kitsuneEntity.Transform.Position = new Vector3(Graphics.Viewport.Size.Width / 2, Graphics.Viewport.Size.Height * 3 / 4, 0);
        kitsuneEntity.AddComponent(new Player(400f));
        kitsuneEntity.AddComponent(new Rigidbody());
        AddEntity(kitsuneEntity);
    }

    protected override void Update()
    {
        base.Update();

    }
}
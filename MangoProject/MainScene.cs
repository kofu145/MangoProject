using Easel.Entities;
using Easel.Graphics;
using Easel.Scenes;
using Easel;
using Easel.Graphics.Renderers;
using MangoProject.Components;

namespace MangoProject;  
using Easel.Entities.Components;

  
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
        kitsuneEntity.AddComponent(new Player(400f));
        AddEntity(kitsuneEntity);
    }

    protected override void Update()
    {
        base.Update();
    }
}

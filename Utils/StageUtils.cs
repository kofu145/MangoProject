using System.Drawing;
using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Utils;

public class StageUtils
{
    public const int Width = 580;
    public const int Height = 720;
    
    public static void MakeBoundRectangles(Scene gameScene)
    {
        
        var borderRect1 = new Entity();
        var borderRect2 = new Entity();
        borderRect1.Transform.Position = new Vector3(-350, 0, 1000);
        borderRect2.Transform.Position = new Vector3(580, 0, 1000);

        borderRect1.AddComponent(new RenderRect(new Vector2(350, GameStateManager.Window.Height)));
        borderRect1.GetComponent<RenderRect>().FillColor = Color.Coral;
        
        borderRect2.AddComponent(new RenderRect(new Vector2(350, GameStateManager.Window.Height)));
        borderRect2.GetComponent<RenderRect>().FillColor = Color.Coral;

        borderRect1.Tag = "border";
        borderRect2.Tag = "border";
        
        gameScene.AddEntity(borderRect1);
        gameScene.AddEntity(borderRect2);
    }

    // TODO: optimize bullets by recycling destroyed ones
    public static void OutOfBoundsCheck(Scene gameScene)
    {
        foreach (var entity in gameScene.Entities)
        {
            var xOffset = GameStateManager.Window.settings.GlobalXOffset;
            if ((entity.Transform.Position.X < -10 || entity.Transform.Position.X > 590 ||
                entity.Transform.Position.Y < -10 || entity.Transform.Position.Y > 730)
                && entity.Tag != "border" && entity.Tag != "player")
            {
                gameScene.DestroyEntity(entity);
            }
        }
    }
}
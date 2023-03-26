using System.Drawing;
using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Utils;

public class StageUtils
{
    public const int Width = 580;
    
    public static void MakeBoundRectangles(Scene gameScene)
    {
        
        var borderRect1 = new Entity();
        var borderRect2 = new Entity();
        borderRect1.Transform.Position.X = -350;
        borderRect2.Transform.Position.X = 580;

        borderRect1.AddComponent(new RenderRect(new Vector2(350, GameStateManager.Window.Height)));
        borderRect1.GetComponent<RenderRect>().FillColor = Color.Coral;
        
        borderRect2.AddComponent(new RenderRect(new Vector2(350, GameStateManager.Window.Height)));
        borderRect2.GetComponent<RenderRect>().FillColor = Color.Coral;
        
        gameScene.AddEntity(borderRect1);
        gameScene.AddEntity(borderRect2);
    }

    // TODO: optimize bullets by recycling destroyed ones
    public static void OutOfBoundsCheck(Scene gameScene)
    {
        foreach (var entity in gameScene.Entities)
        {
            if (entity.Transform.Position.X < -5 || entity.Transform.Position.X > 590 ||
                entity.Transform.Position.Y < -5 || entity.Transform.Position.Y > 725)
            {
                gameScene.DestroyEntity(entity);
            }
        }
    }
}
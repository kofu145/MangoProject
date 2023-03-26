using System.Numerics;
using GramEngine.Core;
using MangoProject.Utils;
using GramEngine.ECS;

namespace MangoProject.Components.MovementBehavior;

public class MoveFromSide : Component
{

    private Side side;
    private float yPos;
    private float speed;
    
    public MoveFromSide(Side side, float yPos, float speed)
    {
        this.side = side;
        this.yPos = yPos;
        this.speed = speed;
        if (side == Side.Right)
        {
            speed = -speed;
            Transform.Position = new Vector3();
        }
    }

    public override void Update(GameTime gameTime)
    {
        
    }
    
}
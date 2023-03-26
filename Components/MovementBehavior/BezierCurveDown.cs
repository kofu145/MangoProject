using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS.Components;
using GramEngine.ECS;
using MangoProject.Utils;

namespace MangoProject.Components.MovementBehavior;

public class BezierCurveDown : Component
{
    private float speed;
    private Vector2 p1;
    private Vector2 p2;
    private Vector2 p3;
    private Vector2 p4;
    private float t;
    
    public BezierCurveDown(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float speed)
    {
        this.speed = speed;
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        this.p4 = p4;
        t = 0;
    }
    
    public override void Initialize()
    {
        base.Initialize();
        
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (Transform.Position.X < 0)
            t = 0;
        Transform.Position = MathUtil.CubicBezierCurve(t, p1, p2, p3, p4).ToVec3();
        // thanks to our border
        //Transform.Position.X += StageUtils.XOffset;
        t += speed * gameTime.DeltaTime;
        Console.WriteLine(t);
    }
}
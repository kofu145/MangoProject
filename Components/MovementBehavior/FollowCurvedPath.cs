using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS;

namespace MangoProject.Components.MovementBehavior;

public class FollowCurvedPath : Component
{
    private float speed;
    private Vector2[] followPositions;
    private int[] curvePositions;
    private float t;
    private int currentPos;
    private int curveCounter;

    public FollowCurvedPath(Vector2[] followPositions, int[] curvePositions, float speed)
    {
        this.speed = speed;
        this.followPositions = followPositions;
        this.curvePositions = curvePositions;
        t = 0;
        currentPos = 1;
        curveCounter = 0;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (currentPos <= followPositions.Length)
        {
            var isCurvePoint = currentPos == curvePositions[curveCounter];
            if (isCurvePoint)
            {
                // two consecutive curve points = cubic curve, not quadratic
                if (currentPos + 1 == curvePositions[curveCounter+1])
                {
                    Transform.Position = MathUtil.ExplicitCubicBezierCurve(t,
                        followPositions[currentPos - 1],
                        followPositions[currentPos],
                        followPositions[currentPos + 1],
                        followPositions[currentPos + 2]
                    ).ToVec3();
                }

                else
                {
                    Transform.Position = MathUtil.QuadraticBezierCurve(t,
                        followPositions[currentPos - 1],
                        followPositions[currentPos],
                        followPositions[currentPos + 1]
                    ).ToVec3();
                }
            }
            else
            {
                Transform.Position = MathUtil.Lerp(followPositions[currentPos - 1], followPositions[currentPos], t).ToVec3();
            }

            if (t > 1)
            {
                if (isCurvePoint)
                {
                    currentPos++;
                    curveCounter++;
                    if (currentPos == curvePositions[curveCounter])
                    {
                        // is a cubic bezier curve, so
                        currentPos++;
                        curveCounter++;
                    }
                }
                t = 0;
                currentPos++;
            }
            
        }
        
        t += speed * gameTime.DeltaTime;
    }
}
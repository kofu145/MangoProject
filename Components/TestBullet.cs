using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components;

public class TestBullet : Component
{
    private CircleCollider collider;
    private Rigidbody rb;
    public override void Initialize()
    {
        collider = ParentEntity.GetComponent<CircleCollider>();
        rb = ParentEntity.GetComponent<Rigidbody>();
        
        var radius = collider.Radius;
        Vector3 newVel = Vector3.Zero;
        
        ParentEntity.GetComponent<CircleCollider>().OnCollision += (CircleCollider other) =>
        {
            //rb.Velocity = -rb.Velocity;
        };
    }
    public override void Update(GameTime gameTime)
    {
        var radius = collider.Radius;
        Vector3 newVel = rb.Velocity;
        
        if (Transform.Position.Y <= radius)
        {
            Transform.Position.Y = radius;
            newVel.Y = -rb.Velocity.Y;
        }

        if (Transform.Position.X <= radius)
        {
            Transform.Position.X = radius;
            newVel.X = -rb.Velocity.X;
        }

        if (Transform.Position.Y >= GameStateManager.Window.Height - radius)
        {
            Transform.Position.Y = GameStateManager.Window.Height - radius - 1;
            newVel.Y = -rb.Velocity.Y;
        }

        if (Transform.Position.X >= GameStateManager.Window.Width - radius)
        {
            Transform.Position.X = GameStateManager.Window.Width - radius - 1;
            newVel.X = -rb.Velocity.X;
        }

        rb.Velocity = newVel;

    }
}
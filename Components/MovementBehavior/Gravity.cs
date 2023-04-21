using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components.MovementBehavior;

public class Gravity : Component
{
    private Rigidbody rb;
    private Vector3 gravity;
    private float capFallSpeed;

    public Gravity(Vector3 gravity, float capFallSpeed)
    {
        this.gravity = gravity;
        this.capFallSpeed = capFallSpeed;
    }

    public override void Initialize()
    {
        base.Initialize();
        rb = ParentEntity.GetComponent<Rigidbody>();
    }

    public override void Update(GameTime gameTime)
    {
        // bandaid fix lmfao
        if (rb == null)
        {
            rb = ParentEntity.GetComponent<Rigidbody>();
        }
        
        base.Update(gameTime);

        rb.Velocity += this.gravity * gameTime.DeltaTime;
        if (rb.Velocity.Y > capFallSpeed)
        {
            rb.Velocity = new Vector3(rb.Velocity.X, capFallSpeed, rb.Velocity.Z);
        }

    }
}
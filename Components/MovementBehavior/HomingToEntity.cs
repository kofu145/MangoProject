using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components.MovementBehavior;

public class HomingToEntity : Component
{
    private Rigidbody rb;
    private Entity target;
    private bool stopAtY;
    private float speed;

    public HomingToEntity(Entity entity, bool stopAtY, float speed)
    {
        target = entity;
        this.stopAtY = stopAtY;
        this.speed = speed;
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
        if (stopAtY && ParentEntity.Transform.Position.Y > target.Transform.Position.Y)
            ParentEntity.RemoveComponent(this);

        var direction = Vector3.Normalize(target.Transform.Position - Transform.Position);

        rb.Velocity = direction * speed;

    }
}
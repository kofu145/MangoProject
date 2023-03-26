using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components;

public class BasicBullet : Component
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
            if (other.ParentEntity.Tag == "Player")
            {
                ParentEntity.GetComponent<Player>()
            }
            //rb.Velocity = -rb.Velocity;
        };
    }
}
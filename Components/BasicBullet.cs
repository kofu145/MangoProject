using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components;

public class BasicBullet : Component
{
    private CircleCollider collider;
    private Rigidbody rb;
    private Player player;
    public override void Initialize()
    {
        collider = ParentEntity.GetComponent<CircleCollider>();
        rb = ParentEntity.GetComponent<Rigidbody>();
        player = ParentScene.FindWithTag("player").GetComponent<Player>();
        
        var radius = collider.Radius;
        Vector3 newVel = Vector3.Zero;
        
        ParentEntity.GetComponent<CircleCollider>().OnCollision += (CircleCollider other) =>
        {
            if (other.ParentEntity.Tag == "player")
            {
                player.TakeDamage();
            }
            //rb.Velocity = -rb.Velocity;
        };
    }
}
using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components;

public class PlayerBullet : Component
{
    private CircleCollider collider;
    private Rigidbody rb;
    private int damage;
    
    public PlayerBullet(int damage)
    {
        this.damage = damage;
    }
    
    public override void Initialize()
    {
        collider = ParentEntity.GetComponent<CircleCollider>();
        rb = ParentEntity.GetComponent<Rigidbody>();
        
        var radius = collider.Radius;
        Vector3 newVel = Vector3.Zero;
        
        ParentEntity.GetComponent<CircleCollider>().OnCollision += (CircleCollider other) =>
        {
            //Console.WriteLine("hit!");
            
            if (other.ParentEntity.HasComponent<Enemy>())
            {
                other.ParentEntity.GetComponent<Enemy>().TakeDamage(damage);
                ParentScene.DestroyEntity(ParentEntity);
            }
            //rb.Velocity = -rb.Velocity;
        };
    }
}
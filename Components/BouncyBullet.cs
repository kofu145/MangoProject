using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components;

public class BouncyBullet : Component
{
    private CircleCollider collider;
    private Rigidbody rb;
    private int bounces;
    private Player player;

    public BouncyBullet(int bounces)
    {
        this.bounces = bounces;
    }
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

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if ((Transform.Position.X <= 0 || Transform.Position.X >= 580 ||
             Transform.Position.Y <= 0 || Transform.Position.Y >= 720) && bounces > 0)
        {
            rb.Velocity = -rb.Velocity;
            bounces--;
        }
    }
}
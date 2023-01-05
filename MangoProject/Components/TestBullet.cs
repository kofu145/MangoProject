using Easel;
using Easel.Entities.Components;
using System.Numerics;
using Easel.Content;
using Easel.Entities;
using Pie.Windowing;

namespace MangoProject.Components;

public class TestBullet : Component
{
    private CircleCollider collider;
    private Rigidbody rb;
    protected override void Initialize()
    {
        collider = GetComponent<CircleCollider>();
        rb = GetComponent<Rigidbody>();
        
        var radius = collider.Radius;
        Vector3 newVel = Vector3.Zero;
        
        Entity.GetComponent<CircleCollider>().OnCollision += (CircleCollider other) =>
        {
            //rb.Velocity = -rb.Velocity;
        };
    }
    protected override void Update()
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

        if (Transform.Position.Y >= Graphics.Viewport.Height - radius)
        {
            Transform.Position.Y = Graphics.Viewport.Height - radius;
            newVel.Y = -rb.Velocity.Y;
        }

        if (Transform.Position.X >= Graphics.Viewport.Width - radius)
        {
            Transform.Position.Y = Graphics.Viewport.Width - radius;
            newVel.X = -rb.Velocity.X;
        }

        rb.Velocity = newVel;

    }
}
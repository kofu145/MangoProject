using Easel;
using Easel.Entities.Components;
using System.Numerics;
using Easel.Content;
using Easel.Entities;
using Pie.Windowing;

namespace MangoProject.Components;

public class Rigidbody : Component
{

    public Vector3 Velocity { get; set; }

    public Rigidbody()
    {
        Velocity = Vector3.Zero;
    }
    public void AddForce(Vector3 force)
    {
        Velocity += force;
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void Update()
    {
        base.Update();
        Transform.Position += Velocity * Time.DeltaTime;

    }
}
using Easel;
using Easel.Entities.Components;
using System.Numerics;
using Easel.Content;
using Easel.Entities;
using Pie.Windowing;

namespace MangoProject.Components;

public class Player: Component
{

    private Key[] inputs = { Key.Up, Key.Down, Key.Left, Key.Right };
    private float speed;
    private Rigidbody rb;

    public Player(float speed)
    {
        this.speed = speed;
    }

    protected override void Initialize()
    {
        base.Initialize();
        rb = GetComponent<Rigidbody>();
    }

    protected override void Update()
    {
        base.Update();

        Vector3 direction = Vector3.Zero;
        
        if (Input.KeyDown(inputs[0]))
            direction.Y = -1;
        if (Input.KeyDown(inputs[1]))
            direction.Y = 1;
        if (Input.KeyDown(inputs[2]))
            direction.X = -1;
        if (Input.KeyDown(inputs[3]))
            direction.X = 1;

        if (direction != Vector3.Zero)
            direction = Vector3.Normalize(direction);
        
        rb.Velocity = direction * speed;

    }
}
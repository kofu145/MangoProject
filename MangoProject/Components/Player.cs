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
    private Vector3 velocity;

    public Player(float speed)
    {
        this.speed = speed;
    }

    protected override void Initialize()
    {
        base.Initialize();
        Transform.Scale = new Vector3(4f, 4f, 2f);
    }

    protected override void Update()
    {
        base.Update();
        velocity = Vector3.Zero;

        if (Input.KeyDown(inputs[0]))
            velocity.Y = -speed;
        if (Input.KeyDown(inputs[1]))
            velocity.Y = speed;
        if (Input.KeyDown(inputs[2]))
            velocity.X = -speed;
        if (Input.KeyDown(inputs[3]))
            velocity.X = speed;

    }
}
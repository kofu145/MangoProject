using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using GramEngine.Core.Input;

namespace MangoProject.Components;

public class Player: Component
{

    private Keys[] inputs = { Keys.W, Keys.S, Keys.A, Keys.D };
    private float speed;
    private Rigidbody rb;
    private bool checker;

    public Player(float speed)
    {
        this.speed = speed;
    }

    public override void Initialize()
    {
        rb = ParentEntity.GetComponent<Rigidbody>();
    }

    public override void Update(GameTime gameTime)
    {
        checker = false;
        Vector3 direction = Vector3.Zero;

        if (InputManager.GetKeyPressed(inputs[0]))
        {
            direction.Y = -1;
        }

        if (InputManager.GetKeyPressed(inputs[1]))
        {
            direction.Y = 1;
        }

        if (InputManager.GetKeyPressed(inputs[2]))
        {
            direction.X = -1;
        }

        if (InputManager.GetKeyPressed(inputs[3]))
        {
            checker = true;
            direction.X = 1;
        }

        if (direction != Vector3.Zero)
            direction = Vector3.Normalize(direction);
        rb.Velocity = direction * speed;

    }
}
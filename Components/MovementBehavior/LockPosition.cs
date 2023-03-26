using GramEngine.Core;
using GramEngine.ECS;

namespace MangoProject.Components.MovementBehavior;

public class LockPosition : Component
{
    private Entity toStalk;
    public LockPosition(Entity entity)
    {
        toStalk = entity;
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        Transform.Position = toStalk.Transform.Position;
    }
}
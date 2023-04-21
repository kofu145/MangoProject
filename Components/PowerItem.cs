using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components;

public class PowerItem : Component
{
    public override void Initialize()
    {
        base.Initialize();
        ParentEntity.GetComponent<CircleCollider>().OnCollision += (CircleCollider other) =>
        {
            //Console.WriteLine("hit!");
            
            if (other.ParentEntity.Tag == "player")
            {
                other.ParentEntity.GetComponent<Player>().AddPower(50);
                ParentScene.DestroyEntity(ParentEntity);
            }
            //rb.Velocity = -rb.Velocity;
        };
    }
}
using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using MangoProject.Components;
using MangoProject.Components.MovementBehavior;

namespace MangoProject.Prefabs;

public class PowerItemPrefab : Prefab
{
    public override Entity Instantiate()
    {
        Entity powerItem = new Entity();
        powerItem.Transform.Scale = new Vector2(3f, 3f);
        powerItem.AddComponent(new Sprite("./Content/power.png"));
        powerItem.AddComponent(new CircleCollider(8*3f, false));
        powerItem.AddComponent(new PowerItem());
        powerItem.AddComponent(new Rigidbody());

        powerItem.GetComponent<Rigidbody>().Velocity = new Vector3(0, -150, 0);
        powerItem.AddComponent(new Gravity(new Vector3(0, 300, 0), 200));
        powerItem.Tag = "item";
        return powerItem;

    }
}
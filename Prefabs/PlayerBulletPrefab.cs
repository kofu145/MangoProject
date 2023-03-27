using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace EirTesting.Prefabs;

public class PlayerBulletPrefab : Prefab
{
    public override Entity Instantiate()
    {
        var entity = new Entity();
        entity.AddComponent(new Sprite("./Content/elongated_bullet_small.png"))
            .AddComponent(new CircleCollider(entity.GetComponent<Sprite>().Width, false, false))
            .AddComponent(new Rigidbody());
        entity.Transform.Scale = new Vector2(2, 2);
        return entity;
    }
}
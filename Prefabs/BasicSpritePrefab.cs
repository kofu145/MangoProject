using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using MangoProject.Components;


namespace MangoProject.Prefabs;

public class BasicSpritePrefab : Prefab
{
    public override Entity Instantiate()
    {
        Entity sprite = new Entity();
        sprite.AddComponent(new Sprite("./Content/forest_sprite.png"))
            .AddComponent(new CircleCollider(28, false))
            .AddComponent(new Enemy(150))
            .AddComponent(new Rigidbody());
        sprite.Transform.Scale = new Vector2(3.5f, 3.5f);
        return sprite;
    }
}
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
            .AddComponent(new Rigidbody())
            .AddComponent(new Sound("./Content/Sound/shoot.wav"));
        sprite.GetComponent<Sound>().Volume = 3;
        sprite.GetComponent<Sound>().Pitch = 1f;
        sprite.Transform.Scale = new Vector2(3.5f, 3.5f);
        sprite.Tag = "enemy";

        return sprite;
    }
}
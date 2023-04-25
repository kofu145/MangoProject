using System.Drawing;
using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using MangoProject.Components;

namespace MangoProject.Prefabs;

public class PlayerBulletPrefab : Prefab
{
    public override Entity Instantiate()
    {
        var entity = new Entity();
        entity.AddComponent(new Sprite("./Content/elongated_bullet_small.png"))
            .AddComponent(new CircleCollider(entity.GetComponent<Sprite>().Width, false, true))
            .AddComponent(new Rigidbody())
            .AddComponent(new PlayerBullet(20));
        entity.Transform.Scale = new Vector2(2, 2);
        entity.GetComponent<Sprite>().Color = Color.FromArgb(100, 255, 255,255);
        return entity;
    }
}
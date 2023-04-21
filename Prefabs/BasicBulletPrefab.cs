using System.Drawing;
using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using MangoProject.Components;

namespace MangoProject.Prefabs;

public class BasicBulletPrefab : Prefab
{
    private float radius;
    public BasicBulletPrefab(float radius)
    {
        this.radius = radius;
    }
    public override Entity Instantiate()
    {
        var entity = new Entity();
        var sprite = entity.AddComponent(new Sprite("Content/elongated_bullet_small.png")).GetComponent<Sprite>();
        var scale = radius / sprite.Width * 2;
        entity.Transform.Scale = new Vector2(scale, scale);
        entity.AddComponent(new Rigidbody(true))
            .AddComponent(new CircleCollider(radius/2, false, false))
            .AddComponent(new BasicBullet())
            .AddComponent(new Sound("./Content/Sound/shoot.wav"));

        entity.Tag = "bullet";
        return entity;
    }
}
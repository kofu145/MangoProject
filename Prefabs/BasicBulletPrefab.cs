using System.Drawing;
using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using MangoProject.Components;

namespace EirTesting.Prefabs;

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
        var sprite = entity.AddComponent(new Sprite("Content/basic_bullet.png")).GetComponent<Sprite>();
        var scale = radius / sprite.Width * 2;
        entity.Transform.Scale = new Vector2(scale, scale);
        entity.AddComponent(new Rigidbody())
            .AddComponent(new CircleCollider(radius, false, false))
            .AddComponent(new BasicBullet());
        entity.AddComponent(new RenderCircle(radius));
        var renderCircle = entity.GetComponent<RenderCircle>();
        renderCircle.FillColor = Color.Empty;
        renderCircle.OutlineColor = Color.Aquamarine;
        renderCircle.BorderThickness = 1;
        renderCircle.Origin = new Vector2(radius, radius);

        entity.Tag = "bullet";
        return entity;
    }
}
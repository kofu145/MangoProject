using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using MangoProject.Components.BulletPatterns;
using MangoProject.Components.MovementBehavior;

namespace MangoProject.Prefabs;

public class BasicForestPixie : Prefab
{
    private Vector2 p1;
    private Vector2 p2;
    private Vector2 p3;
    private Vector2 p4;
    private float speed;
    public BasicForestPixie(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4, float speed)
    {
        this.speed = speed;
        this.p1 = p1;
        this.p2 = p2;
        this.p3 = p3;
        this.p4 = p4;
    }
    public override Entity Instantiate()
    {
        var pixie = new Entity();
        pixie.AddComponent(new Sprite("./Content/forest_pixie.png"));
        pixie.AddComponent(new BezierCurveDown(p1, p2, p3, p4, speed));
        //pixie.AddComponent(new ShotgunCone(48, 5, 200, true, 1.5f, 1, 10));
        //pixie.AddComponent(new StackedShotgun(12, 20, 5, 150, true, 1.5f, 1, 5, 4));
        //pixie.AddComponent(new CircleOfBullets(12, 50, 16, 150, true, true, 1.5f, 1, 0, 1));
        //pixie.AddComponent(new SpinBulletGenerator(12, 50, 16, 150, true, 1.2f, 1, 0, 1, 11));

        var sprite = pixie.GetComponent<Sprite>();
        pixie.Transform.Position = new Vector3(550, 5, 0);
        pixie.Transform.Scale = new Vector2(3.5f, 3.5f);//, 2f);
        return pixie;
    }
}
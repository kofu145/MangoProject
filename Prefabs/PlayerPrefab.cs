using System.Drawing;
using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using MangoProject.Components;

namespace EirTesting.Prefabs;

public class PlayerPrefab : Prefab
{
    Entity kitsuneEntity;

    public override Entity Instantiate()
    {
        kitsuneEntity = new Entity();
        kitsuneEntity.AddComponent(new Sprite("./Content/kitsune.png"));
        kitsuneEntity.Transform.Scale = new Vector2(2f, 2f);//, 0f);
        kitsuneEntity.Transform.Position = new Vector3(500, 500, 0);
        kitsuneEntity.AddComponent(new Player(250, 125, 3, .13f, 4 , .05f));
        kitsuneEntity.AddComponent(new Rigidbody());
        kitsuneEntity.AddComponent(new CircleCollider(8, false, true));
        kitsuneEntity.AddComponent(new RenderCircle(8));
        var renderCircle = kitsuneEntity.GetComponent<RenderCircle>();
        renderCircle.FillColor = Color.Empty;
        renderCircle.OutlineColor = Color.Cornsilk;
        renderCircle.BorderThickness = 1;
        kitsuneEntity.Tag = "player";
        return kitsuneEntity;
    }
}
using System.Drawing;
using System.Numerics;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using MangoProject.Components;

namespace MangoProject.Prefabs;

public class PlayerPrefab : Prefab
{
    Entity kitsuneEntity;

    public override Entity Instantiate()
    {
        kitsuneEntity = new Entity();
        kitsuneEntity.AddComponent(new Sprite("./Content/kitsune.png"));
        kitsuneEntity.Transform.Scale = new Vector2(2f, 2f);//, 0f);
        kitsuneEntity.Transform.Position = new Vector3(500, 500, 0);
        kitsuneEntity.AddComponent(new Player(280, 150, 3, .13f, 4 , .02f));
        kitsuneEntity.AddComponent(new Rigidbody());
        kitsuneEntity.AddComponent(new CircleCollider(8, false, true));
        kitsuneEntity.Tag = "player";
        return kitsuneEntity;
    }
}
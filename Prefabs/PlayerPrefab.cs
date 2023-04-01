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
        kitsuneEntity.AddComponent(new Player(250, 125, 3, .13f, 4 , .1f));
        kitsuneEntity.AddComponent(new Rigidbody());
        kitsuneEntity.Tag = "player";
        //kitsuneEntity.AddComponent(new CircleCollider());
        return kitsuneEntity;
    }
}
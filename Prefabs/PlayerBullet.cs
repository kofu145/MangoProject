using GramEngine.ECS;

namespace EirTesting.Prefabs;

public class PlayerBullet : Prefab
{
    public override Entity Instantiate()
    {
        return new Entity();
    }
}
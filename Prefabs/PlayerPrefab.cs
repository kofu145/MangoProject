using GramEngine.ECS;

namespace EirTesting.Prefabs;

public class PlayerPrefab : Prefab
{
    public override Entity Instantiate()
    {
        return new Entity();
    }
}
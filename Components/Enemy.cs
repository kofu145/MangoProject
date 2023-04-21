using GramEngine.Core;
using GramEngine.ECS;
using MangoProject.Prefabs;

namespace MangoProject.Components;

public class Enemy : Component
{
    public int MaxHP;
    public int HP;
    private PowerItemPrefab powerItemPrefab;
    
    public Enemy(int maxHP)
    {
        MaxHP = maxHP;
        HP = maxHP;

        // TODO: prob not the best idea, ideally have one prefab for all enemies but this does for now
        powerItemPrefab = new PowerItemPrefab();
    }

    public override void OnLoad()
    {

    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (HP <= 0)
        {
            ParentScene.DestroyEntity(ParentEntity);
            var powerItem = powerItemPrefab.Instantiate();
            powerItem.Transform.Position = ParentEntity.Transform.Position;
            ParentScene.AddEntity(powerItem);
        }

    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }
}
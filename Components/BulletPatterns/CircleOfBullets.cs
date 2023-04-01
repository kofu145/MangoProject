using System.Numerics;
using GramEngine.Core;
using GramEngine.ECS;

namespace MangoProject.Components.BulletPatterns;

public class CircleOfBullets : Component
{
    private int numBullets;
    private int bulletSpeed;
    private bool repeating;
    private float attackSpeed;
    private float nextFire;
    private Player player;

    public CircleOfBullets(int numBullets, int bulletSpeed, bool repeating, float attackSpeed, float initialDelay)
    {
        this.numBullets = numBullets;
        this.bulletSpeed = bulletSpeed;
        this.repeating = repeating;
        this.attackSpeed = attackSpeed;
        nextFire = (float)GameStateManager.GameTime.TotalTime.TotalSeconds + initialDelay;
        
    }
    
    public override void Initialize()
    {
        base.Initialize();
        player = ParentScene.FindWithTag("player").GetComponent<Player>();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        if (gameTime.TotalTime.TotalSeconds > nextFire)
        {
            
        }
    }
}
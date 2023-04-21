using System.Numerics;
using MangoProject.Prefabs;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components.BulletPatterns;

public class StackedShotgun : Component
{
    private int numBullets;
    private float bulletSpeed;
    private bool repeating;
    private float attackSpeed;
    private float nextFire;
    private Player player;
    private float offsetAngle;
    private float decrementSpeed;
    private int rows;
    private BasicBulletPrefab bulletPrefab;
    public StackedShotgun(
        float bullRadius, float decrementSpeed, int numBullets, float bulletSpeed, bool repeating, 
        float attackSpeed, float initialDelay, float offsetAngle, int rows
        )
    {
        this.numBullets = numBullets;
        this.bulletSpeed = bulletSpeed;
        this.repeating = repeating;
        this.attackSpeed = attackSpeed;
        this.decrementSpeed = decrementSpeed;
        this.rows = rows;
        this.offsetAngle = offsetAngle;
        nextFire = (float)GameStateManager.GameTime.TotalTime.TotalSeconds + initialDelay;
        bulletPrefab = new BasicBulletPrefab(bullRadius);
        
    }
    public override void Initialize()
    {
        player = ParentScene.FindWithTag("player").GetComponent<Player>();

    }

    public override void Update(GameTime gameTime)
    {
        // get normalized direction vector from current entity to player position
        // fire!!!
        if (gameTime.TotalTime.TotalSeconds > nextFire)
        {
            var origBullSpeed = bulletSpeed;
            for (int i = 0; i < rows; i++)
            {
                var direction = player.Transform.Position - Transform.Position;
                var angle = Math.Atan2(direction.Y, direction.X) -MathUtil.DegToRad((offsetAngle * (numBullets-1))/2);
                angle = offsetAngle%2 == 0? angle : angle - MathUtil.DegToRad(offsetAngle/2);
                for (int j = 0; j < numBullets; j++)
                {
                    var bullet = bulletPrefab.Instantiate();
                    var fireAngle = angle + MathUtil.DegToRad(offsetAngle * j);
                    direction = Vector3.Normalize(new Vector3((float)Math.Cos(fireAngle), (float)Math.Sin(fireAngle), 0));
                    bullet.GetComponent<Rigidbody>().Velocity = direction * bulletSpeed;
                    bullet.Transform.Position = Transform.Position;
                    bullet.GetComponent<Sound>().Play();
                    ParentScene.AddEntity(bullet);
                }

                bulletSpeed -= decrementSpeed;
            }

            bulletSpeed = origBullSpeed;
            
            if (repeating)
                nextFire = (float)gameTime.TotalTime.TotalSeconds + attackSpeed;
        }
    }
}
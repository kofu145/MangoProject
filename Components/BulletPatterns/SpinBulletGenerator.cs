using System.Numerics;
using EirTesting.Prefabs;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components.BulletPatterns;

public class SpinBulletGenerator : Component
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
    private float spinAngle;
    private BasicBulletPrefab bulletPrefab;
    public SpinBulletGenerator(
        float bullRadius, float decrementSpeed, int numBullets, float bulletSpeed, 
        bool repeating, float attackSpeed, float initialDelay, 
        float offsetAngle, int rows, float spinAngle
        )
    {
        this.numBullets = numBullets;
        this.bulletSpeed = bulletSpeed;
        this.repeating = repeating;
        this.attackSpeed = attackSpeed;
        this.decrementSpeed = decrementSpeed;
        this.rows = rows;
        this.spinAngle = spinAngle;
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
                Vector3 direction;
                
                double angle = 0;

                angle = 0 - offsetAngle;
                
                //angle = offsetAngle%2 == 0? angle : angle - MathUtil.DegToRad(offsetAngle/2);
                var offset = 360.0 / numBullets;// + spinAngle;
                
                for (int j = 0; j < numBullets; j++)
                {
                    var bullet = bulletPrefab.Instantiate();
                    var fireAngle = MathUtil.DegToRad(angle + offset * j);
                    direction = Vector3.Normalize(new Vector3((float)Math.Cos(fireAngle), (float)Math.Sin(fireAngle), 0));
                    bullet.GetComponent<Rigidbody>().Velocity = direction * bulletSpeed;
                    bullet.Transform.Position = Transform.Position;
                    ParentScene.AddEntity(bullet);
                }

                bulletSpeed -= decrementSpeed;
            }

            //spinAngle += spinAngle;
            offsetAngle += spinAngle;
            
            bulletSpeed = origBullSpeed;
            
            if (repeating)
                nextFire = (float)gameTime.TotalTime.TotalSeconds + attackSpeed;
        }
    }
}
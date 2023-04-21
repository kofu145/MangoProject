using System.Numerics;
using MangoProject.Prefabs;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;

namespace MangoProject.Components.BulletPatterns;

public class ShotgunCone : Component
{
    private int numBullets;
    private int bulletSpeed;
    private bool repeating;
    private float attackSpeed;
    private float nextFire;
    private Player player;
    private float offsetAngle;
    private float bulletOffsetTime;
    private float bulletOffsetEvent;
    private bool inFire;
    private int currentBull;
    private BasicBulletPrefab bulletPrefab;
    private BouncyBulletPrefab bouncyBulletPrefab;
    private bool useBouncyBull;
    public ShotgunCone(float bullRadius, int numBullets, int bulletSpeed, bool repeating, float attackSpeed, 
        float initialDelay, float offsetAngle, float bulletOffsetTime, bool useBouncyBull)
    {
        this.numBullets = numBullets;
        this.bulletSpeed = bulletSpeed;
        this.repeating = repeating;
        this.attackSpeed = attackSpeed;
        this.offsetAngle = offsetAngle;
        this.bulletOffsetTime = bulletOffsetTime;
        this.currentBull = 0;
        inFire = false;
        this.bulletOffsetEvent = 0;
        nextFire = (float)GameStateManager.GameTime.TotalTime.TotalSeconds + initialDelay;
        bulletPrefab = new BasicBulletPrefab(bullRadius);
        bouncyBulletPrefab = new BouncyBulletPrefab(bullRadius, 1);
        this.useBouncyBull = useBouncyBull;

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
            inFire = true;

        }

        var direction = player.Transform.Position - Transform.Position;
        var angle = Math.Atan2(direction.Y, direction.X) -MathUtil.DegToRad((offsetAngle * (numBullets-1))/2);
        angle = offsetAngle%2 == 0? angle : angle - MathUtil.DegToRad(offsetAngle/2);
            if ((float)gameTime.TotalTime.TotalSeconds >= bulletOffsetEvent && inFire)
            {
                Entity bullet;
                if (useBouncyBull)
                    bullet = bouncyBulletPrefab.Instantiate();
                else
                    bullet = bulletPrefab.Instantiate();
                var fireAngle = angle + MathUtil.DegToRad(offsetAngle * currentBull);
                direction = Vector3.Normalize(new Vector3((float)Math.Cos(fireAngle), (float)Math.Sin(fireAngle), 0));
                bullet.GetComponent<Rigidbody>().Velocity = direction * bulletSpeed;
                bullet.Transform.Position = Transform.Position;
                bullet.GetComponent<Sound>().Play();
                
                ParentScene.AddEntity(bullet);
                bulletOffsetEvent = (float)gameTime.TotalTime.TotalSeconds + bulletOffsetTime;
                currentBull++;
                if(currentBull >= numBullets)
                {
                    inFire = false;
                    currentBull = 0;
                    if (repeating)
                        nextFire = (float)gameTime.TotalTime.TotalSeconds + attackSpeed;
                }
        }
    }
}
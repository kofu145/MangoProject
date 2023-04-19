using System.Diagnostics;
using System.Numerics;
using MangoProject.Prefabs;
using GramEngine.Core;
using MangoProject.Components.BulletPatterns;

namespace MangoProject.Events.StageOne;

public class DoublePixieSpin : IEvent
{
    public float TriggerTime { get; }
    public bool Finished { get; }

    private Stopwatch spawnTimer;
    private int enemiesToSpawn;
    private int enemiesSpawned;
    private float spawnRate;
    private float nextSpawn;
    private BasicForestPixie rightPixie;
    private BasicForestPixie leftPixie;


    public DoublePixieSpin(float triggerTime, int enemiesToSpawn, float spawnRate)
    {
        TriggerTime = triggerTime;
        this.enemiesToSpawn = enemiesToSpawn;
        this.spawnRate = spawnRate;
        nextSpawn = 0;
        enemiesSpawned = 0;
        spawnTimer = new Stopwatch();
        rightPixie = new BasicForestPixie(
            new Vector2(580, 200),
            new Vector2(390, 200),
            new Vector2(390, 200),
            new Vector2(390, 200),
            .15f
        );
        leftPixie = new BasicForestPixie(
            new Vector2(0, 200),
            new Vector2(190, 200),
            new Vector2(190, 200),
            new Vector2(190, 200),
            .15f
        );
    }
    
    public void Start()
    {
        spawnTimer.Start();
        GameStateManager.GetScreen().GameScene.AddEntity(rightPixie.Instantiate()
            .AddComponent(new SpinBulletGenerator(12, 50, 2, 220,
                true, .2f, 1, 0, 1, 24)));
        GameStateManager.GetScreen().GameScene.AddEntity(leftPixie.Instantiate()
            .AddComponent(new SpinBulletGenerator(12, 50, 2, 220,
                true, .2f, 1, 0, 1, -24)));
    }

    public void Update(GameTime gameTime)
    {
        if (gameTime.TotalTime.TotalSeconds > nextSpawn && enemiesSpawned < enemiesToSpawn)
        {

            nextSpawn = (float) gameTime.TotalTime.TotalSeconds + spawnRate;
            enemiesSpawned++;
        }
    }
}
using System.Diagnostics;
using System.Numerics;
using EirTesting.Prefabs;
using GramEngine.Core;
using MangoProject.Components.BulletPatterns;

namespace MangoProject.Events.StageOne;

public class DownCurvePathPixies : IEvent
{
    public float TriggerTime { get; }
    public bool Finished { get; }

    private Stopwatch spawnTimer;
    private int enemiesToSpawn;
    private int enemiesSpawned;
    private float spawnRate;
    private float nextSpawn;
    private BasicForestPixie pixie;
    private BasicForestPixie downPixie;


    public DownCurvePathPixies(float triggerTime, int enemiesToSpawn, float spawnRate)
    {
        TriggerTime = triggerTime;
        this.enemiesToSpawn = enemiesToSpawn;
        this.spawnRate = spawnRate;
        nextSpawn = 0;
        enemiesSpawned = 0;
        spawnTimer = new Stopwatch();
        pixie = new BasicForestPixie(
            new Vector2(-3, 0),
            new Vector2(1500, 0),
            new Vector2(-920, 400),
            new Vector2(583, 400),
            .15f
        );
        downPixie = new BasicForestPixie(
            new Vector2(290, 0),
            new Vector2(290, 0),
            new Vector2(290, 300),
            new Vector2(290, 300),
            .15f
        );
    }
    
    public void Start()
    {
        spawnTimer.Start();
        GameStateManager.GetScreen().GameScene.AddEntity(downPixie.Instantiate()
            .AddComponent(new SpinBulletGenerator(12, 50, 32, 150,
                true, 1.2f, 1, 0, 1, 11)));
    }

    public void Update(GameTime gameTime)
    {
        if (gameTime.TotalTime.TotalSeconds > nextSpawn && enemiesSpawned < enemiesToSpawn)
        {
            GameStateManager.GetScreen().GameScene.AddEntity(pixie.Instantiate()
                .AddComponent(new StackedShotgun(12, 40, 1, 220, true, 
                    1f, 1, 10, 4)));
            

            nextSpawn = (float) gameTime.TotalTime.TotalSeconds + spawnRate;
            enemiesSpawned++;
        }
    }
}
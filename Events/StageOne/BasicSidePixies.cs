using System.Diagnostics;
using System.Numerics;
using EirTesting.Prefabs;
using GramEngine.Core;
using MangoProject.Components.BulletPatterns;

namespace MangoProject.Events.StageOne;

public class BasicSidePixies : IEvent
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

    public BasicSidePixies(float triggerTime, int enemiesToSpawn, float spawnRate)
    {
        TriggerTime = triggerTime;
        this.enemiesToSpawn = enemiesToSpawn;
        this.spawnRate = spawnRate;
        nextSpawn = 0;
        enemiesSpawned = 0;
        spawnTimer = new Stopwatch();
        rightPixie = new BasicForestPixie(
            new Vector2(585, 200),
            new Vector2(300, 200),
            new Vector2(100, 150),
            new Vector2(100, -15),
            .2f
        );
        leftPixie = new BasicForestPixie(
            new Vector2(-5, 200),
            new Vector2(300, 200),
            new Vector2(480, 150),
            new Vector2(480, -15),
            .2f
        );
    }
    
    public void Start()
    {
        spawnTimer.Start();
    }

    public void Update(GameTime gameTime)
    {
        if (gameTime.TotalTime.TotalSeconds > nextSpawn && enemiesSpawned < enemiesToSpawn)
        {
            GameStateManager.GetScreen().GameScene.AddEntity(rightPixie.Instantiate().AddComponent(
                new SpinBulletGenerator(12, 50, 20, 150,
                    true, 1.2f, 1, 0, 1, 11)));
            GameStateManager.GetScreen().GameScene.AddEntity(leftPixie.Instantiate().AddComponent(
                new SpinBulletGenerator(12, 50, 20, 150,
                    true, 1.2f, 1, 0, 1, 11)));
            nextSpawn = (float) gameTime.TotalTime.TotalSeconds + spawnRate;
            enemiesSpawned++;
        }
    }
}
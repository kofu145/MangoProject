using System.Diagnostics;
using System.Numerics;
using EirTesting.Prefabs;
using GramEngine.Core;

namespace MangoProject.Events.StageOne;

public class BasicSideFairies : IEvent
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

    public BasicSideFairies(float triggerTime, int enemiesToSpawn, float spawnRate)
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
            .3f
        );
        leftPixie = new BasicForestPixie(
            new Vector2(585, 200),
            new Vector2(300, 200),
            new Vector2(100, 150),
            new Vector2(100, -15),
            .3f
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
            GameStateManager.GetScreen().GameScene.AddEntity(rightPixie.Instantiate());
            nextSpawn = (float) gameTime.TotalTime.TotalSeconds + spawnRate;
            enemiesSpawned++;
        }
    }
}
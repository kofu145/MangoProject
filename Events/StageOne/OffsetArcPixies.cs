using System.Diagnostics;
using System.Numerics;
using MangoProject.Prefabs;
using GramEngine.Core;
using MangoProject.Components.BulletPatterns;

namespace MangoProject.Events.StageOne;

public class OffsetArcPixies : IEvent
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


    public OffsetArcPixies(float triggerTime, int enemiesToSpawn, float spawnRate)
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
    }

    public void Update(GameTime gameTime)
    {
        if (gameTime.TotalTime.TotalSeconds > nextSpawn && enemiesSpawned < enemiesToSpawn)
        {
            GameStateManager.GetScreen().GameScene.AddEntity(pixie.Instantiate()
                .AddComponent(new ShotgunCone(12, 14, 170, true, 5f, 
                    .5f, 4, .02f, true)));
            

            nextSpawn = (float) gameTime.TotalTime.TotalSeconds + spawnRate;
            enemiesSpawned++;
        }
    }
}
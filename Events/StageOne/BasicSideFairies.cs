using System.Diagnostics;
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

    public BasicSideFairies(float triggerTime, int enemiesToSpawn, float spawnRate)
    {
        TriggerTime = triggerTime;
        this.enemiesToSpawn = enemiesToSpawn;
        this.spawnRate = spawnRate;
        nextSpawn = 0;
        enemiesSpawned = 0;
    }
    
    public void Start()
    {
        spawnTimer.Start();
    }

    public void Update(GameTime gameTime)
    {
        if (spawnTimer.Elapsed.Seconds > nextSpawn && enemiesSpawned < enemiesToSpawn)
        {
            
        }
    }
}
using System.Diagnostics;
using System.Numerics;
using MangoProject.Prefabs;
using GramEngine.Core;
using MangoProject.Components.BulletPatterns;
using MangoProject.Components.MovementBehavior;

namespace MangoProject.Events.StageOne;

public class HomingGhosts : IEvent
{
    public float TriggerTime { get; }
    public bool Finished { get; }

    private Stopwatch spawnTimer;
    private int enemiesToSpawn;
    private int enemiesSpawned;
    private float spawnRate;
    private float nextSpawn;
    private BasicSpritePrefab spritePrefab;

    public HomingGhosts(float triggerTime, int enemiesToSpawn, float spawnRate)
    {
        TriggerTime = triggerTime;
        this.enemiesToSpawn = enemiesToSpawn;
        this.spawnRate = spawnRate;
        nextSpawn = 0;
        enemiesSpawned = 0;
        spawnTimer = new Stopwatch();
        spritePrefab = new BasicSpritePrefab();
    }
    
    public void Start()
    {
        spawnTimer.Start();
    }

    public void Update(GameTime gameTime)
    {
        if (gameTime.TotalTime.TotalSeconds > nextSpawn && enemiesSpawned < enemiesToSpawn)
        {
            var player = GameStateManager.GetScreen().GameScene.Entities.Where(e => e.Tag == "player").First();
            var sprite = spritePrefab.Instantiate();
            sprite.AddComponent(new HomingToEntity(player, true, 150));
            sprite.Transform.Position = new Vector3(290, 0, 0);
            sprite.AddComponent(new ShotgunCone(12, 1, 240, true, 1f, .2f, 0, 0, false));
            GameStateManager.GetScreen().GameScene.AddEntity(sprite);
            Console.WriteLine("spawned sprite");
            nextSpawn = (float) gameTime.TotalTime.TotalSeconds + spawnRate;
            enemiesSpawned++;
        }
    }
}
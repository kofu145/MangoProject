﻿using System.Drawing;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using System.Numerics;
using EirTesting.Prefabs;
using MangoProject.Components;
using MangoProject.Components.MovementBehavior;
using MangoProject.Utils;

namespace MangoProject.Scenes;

public class TestEnemiesScene : GameState
{
    private Entity kitsuneEntity;
    private Entity pixie;

    public override void Initialize()
    {
        PlayerPrefab playerPrefab = new PlayerPrefab();
        kitsuneEntity = playerPrefab.Instantiate();

        pixie = new Entity();
        Console.WriteLine(pixie.Transform.Position);
        pixie.AddComponent(new Sprite("./Content/forest_pixie.png"));
        pixie.AddComponent(new BezierCurveDown(
            new Vector2(550, -5),
            new Vector2(500, 300),
            new Vector2(400, 400),
            new Vector2(0, 300),
            .3f
            ));
        var sprite = pixie.GetComponent<Sprite>();
        pixie.Transform.Position = new Vector3(550, 5, 0);
        pixie.Transform.Scale = new Vector2(3.5f, 3.5f);//, 2f);
        sprite.Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

        Console.WriteLine(pixie.Transform.Position);
        AddEntity(pixie);
        AddEntity(kitsuneEntity);
        StageUtils.MakeBoundRectangles(GameScene);
    }

    public override void Update(GameTime gameTime)
    {
        //Console.WriteLine(GameScene.Entities.Count);
        //Console.WriteLine(pixie.Transform.Position);
    }
}
﻿using System.Drawing;
using GramEngine.Core;
using GramEngine.ECS;
using GramEngine.ECS.Components;
using System.Numerics;
using MangoProject.Prefabs;
using MangoProject.Components;
using MangoProject.Components.BulletPatterns;
using MangoProject.Components.MovementBehavior;
using MangoProject.Events;
using MangoProject.Events.StageOne;
using MangoProject.Utils;
using SFML.System;

namespace MangoProject.Scenes;

public class TestEnemiesScene : GameState
{
    private Entity kitsuneEntity;
    private Entity pixie;
    private Timeline timeline;

    public override void Initialize()
    {
        PlayerPrefab playerPrefab = new PlayerPrefab();
        kitsuneEntity = playerPrefab.Instantiate();

        pixie = new Entity();
        Console.WriteLine(pixie.Transform.Position);
        pixie.AddComponent(new Sprite("./Content/forest_pixie.png"));
        /*pixie.AddComponent(new BezierCurveDown(
            new Vector2(550, -5),
            new Vector2(500, 300),
            new Vector2(400, 400),
            new Vector2(0, 300),
            .3f
            ));*/
        //pixie.AddComponent(new ShotgunCone(48, 10, 200, true, .8f, 0, 10));
        //pixie.AddComponent(new StackedShotgun(48, 50, 10, 200, true, .8f, 0, 10, 2));
        pixie.AddComponent(new SpinBulletGenerator(12, 50, 3, 150, true,
            .09f, 1, 0, 3, 13));
        //pixie.AddComponent(new StackedShotgun(8, 50, 9, 200, true, .8f, 0, 10, 2));

        var sprite = pixie.GetComponent<Sprite>();
        //pixie.Transform.Position = new Vector3(550, 5, 0);
        pixie.Transform.Position = new Vector3(300, 200, 0);

        pixie.Transform.Scale = new Vector2(3.5f, 3.5f);//, 2f);
        sprite.Origin = new Vector2(sprite.Width / 2, sprite.Height / 2);

        timeline = new Timeline();
        //timeline.AddEvent(new OffsetArcPixies(0, 5, 1));
        timeline.AddEvent(new HomingGhosts(0, 5, 1));
        timeline.AddEvent(new DoublePixieSpin(10, 5, 1));
        timeline.AddEvent(new DownCurvePathPixies(20, 5, 1));
        timeline.AddEvent(new BasicSidePixies(30, 5, 1));

        timeline.BeginTimeline();

       // Console.WriteLine(pixie.Transform.Position);
        //AddEntity(pixie);
        AddEntity(kitsuneEntity);
        StageUtils.MakeBoundRectangles(GameScene);
    }

    public override void Update(GameTime gameTime)
    {
        //Console.WriteLine(GameScene.Entities.Count);
        //Console.WriteLine(pixie.Transform.Position);
        //Console.WriteLine(gameTime.DeltaTime);
        Console.WriteLine(kitsuneEntity.Transform.Position);
        timeline.UpdateEvents(gameTime);
        StageUtils.OutOfBoundsCheck(GameScene);
    }
}
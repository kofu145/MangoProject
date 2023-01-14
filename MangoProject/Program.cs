using Easel;  
using Easel.Math;  
using MangoProject;
using Pie;
using Pie.Windowing;
using Easel.Graphics;
using Easel.Graphics.Renderers;
using MangoProject.Scenes;

GameSettings gameSettings = new GameSettings()  
{  
    Title = "MangoProject",
    Size = new Size(1280, 720),
    Border = WindowBorder.Resizable
};

using EaselGame game = new EaselGame(gameSettings, new StageOne());

Logger.UseConsoleLogs();
game.Run();
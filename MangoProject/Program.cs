using Easel;  
using Easel.Math;  
using MangoProject;
using Pie;
using Pie.Windowing;
using Easel.Graphics;
using Easel.Graphics.Renderers;


GameSettings gameSettings = new GameSettings()  
{  
    Title = "MangoProject",
    Size = new Size(1920, 1080),
    Border = WindowBorder.Borderless
};

using EaselGame game = new EaselGame(gameSettings, new MainScene());

Logger.UseConsoleLogs();
game.Run();
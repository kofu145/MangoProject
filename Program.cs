// See https://aka.ms/new-console-template for more information
using GramEngine.Core;
using System;
using MangoProject.Scenes;

namespace MangoProject // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WindowSettings windowSettings = new WindowSettings()
            {
                GlobalXOffset = 350,
                ShowColliders = true
            };
            Window window = new Window(new TestEnemiesScene(), windowSettings);
            window.Run();
            
        }
    }
}
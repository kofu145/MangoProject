// See https://aka.ms/new-console-template for more information
using GramEngine.Core;
using System;
using MangoProject.Scene;

namespace EirTesting // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Window window = new Window(initialGameState: new TestScene());
            window.Run();
        }
    }
}
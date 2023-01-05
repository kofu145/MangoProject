using Easel.Entities;
using Easel.Graphics;
using Easel.Scenes;
using Easel;
using Easel.Graphics.Renderers;
using MangoProject.Components;
using System.Numerics;

namespace MangoProject.Events
{
    public interface IEvent
    {
        public float TriggerTime { get; }
        public bool Finished { get; }

        public void Start();

        public void Update(float gameTime);
    }
}
using MangoProject.Components;
using System.Numerics;
using GramEngine.Core;

namespace MangoProject.Events
{
    public interface IEvent
    {
        public float TriggerTime { get; }
        public bool Finished { get; }

        public void Start();

        public void Update(GameTime gameTime);
    }
}
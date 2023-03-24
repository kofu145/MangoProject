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
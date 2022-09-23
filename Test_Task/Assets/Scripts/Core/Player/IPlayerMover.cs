using UnityEngine;

namespace Core
{
    public interface IPlayerMover
    {
        public Vector3 Velocity { get; }
        
        public void MoveTo(Vector3 position);

        public void StopMove();
    }
}
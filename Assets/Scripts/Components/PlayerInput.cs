using Unity.Entities;

namespace Components
{
    public struct PlayerInput : IComponentData
    {
        public float Horizontal;
        public float Vertical;
        public bool FireButton;
    }
}
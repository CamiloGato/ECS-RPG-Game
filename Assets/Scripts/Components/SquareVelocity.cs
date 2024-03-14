using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct SquareVelocity : IComponentData
    {
        public float3 Direction;
        public float Speed;
    }
}
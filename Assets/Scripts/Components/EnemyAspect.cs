using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace Components
{
    public readonly partial struct EnemyAspect : IAspect
    {
        public readonly Entity Entity;

        private readonly RefRW<LocalTransform> _localTransform;
        private readonly RefRO<EnemyMovement> _enemyMovement;

        public void Move(float deltaTime)
        {
            _localTransform.ValueRW.Position += new float3(1, 0, 0) * _enemyMovement.ValueRO.Velocity * deltaTime;
        }

    }
}
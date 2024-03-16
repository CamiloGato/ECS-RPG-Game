using Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Systems
{
    public partial struct SquareMovement : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<SquareVelocity>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            SquareMovementJob squareMovement = new SquareMovementJob()
            {
                DeltaTime = SystemAPI.Time.DeltaTime
            };
            squareMovement.Schedule();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }

    public partial struct SquareMovementJob : IJobEntity
    {
        public float DeltaTime;

        private void Execute(ref LocalTransform transform, in SquareVelocity velocity)
        {
            transform.Position += velocity.Direction * DeltaTime;
        }
    } 
    
}
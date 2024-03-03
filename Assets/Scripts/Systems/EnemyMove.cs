using Systems.Jobs;
using Unity.Burst;
using Unity.Entities;

namespace Systems
{
    public partial struct EnemyMove : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            var deltaTime = SystemAPI.Time.DeltaTime;

            new ProcessEnemyMove()
            {
                DeltaTime = deltaTime
            }.ScheduleParallel();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}
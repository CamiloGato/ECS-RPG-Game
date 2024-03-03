using Components;
using Unity.Burst;
using Unity.Entities;

namespace Systems.Jobs
{
    [BurstCompile]
    public partial struct ProcessEnemyMove : IJobEntity
    {
        public float DeltaTime;
        
        [BurstCompile]
        public void Execute(EnemyAspect enemy)
        {
            enemy.Move(DeltaTime);
        }
    }
}
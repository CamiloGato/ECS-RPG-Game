using Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

namespace Systems.Jobs
{
    [BurstCompile]
    public partial struct ProcessSpawner : IJobEntity
    {
        public EntityCommandBuffer.ParallelWriter Ecb;
        public double ElapsedTime;
        
        public void Execute( [ChunkIndexInQuery] int chunkIndex, ref Spawner spawner )
        {
            if (spawner.NextSpawnTime < ElapsedTime)
            {
                Entity newEntity = Ecb.Instantiate(chunkIndex, spawner.Prefab);
                
                Ecb.SetComponent(
                    chunkIndex,
                    newEntity,
                    LocalTransform.FromPosition(spawner.SpawnPoint)
                    );
                
                spawner.NextSpawnTime = (float)ElapsedTime + spawner.SpawnRate;
            }
        }
    }
}
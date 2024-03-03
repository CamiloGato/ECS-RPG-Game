using Components;
using Unity.Burst;
using Unity.Entities;

namespace Systems
{
    public partial struct Spawn : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<BeginSimulationEntityCommandBufferSystem.Singleton>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            EntityCommandBuffer.ParallelWriter ecb = GetEntityCommandBuffer(ref state);
            
            foreach (RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
            {
                new Jobs.ProcessSpawner()
                {
                    ElapsedTime = SystemAPI.Time.ElapsedTime,
                    Ecb = ecb
                }.ScheduleParallel();
            }
        }

        private EntityCommandBuffer.ParallelWriter GetEntityCommandBuffer(ref SystemState state)
        {
            var ecbSingleton = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>();
            var ecb = ecbSingleton.CreateCommandBuffer(state.WorldUnmanaged);
            return ecb.AsParallelWriter();
        }

        // private void ProcessSpawner(ref SystemState state, RefRW<Spawner> spawner)
        // {
        //     if (spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime)
        //     {
        //         Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.Prefab);
        //         
        //         state.EntityManager.SetComponentData(
        //             newEntity,
        //             LocalTransform.FromPosition(spawner.ValueRO.SpawnPoint)
        //             );
        //
        //         spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnRate;
        //     }
        // }
    }
}
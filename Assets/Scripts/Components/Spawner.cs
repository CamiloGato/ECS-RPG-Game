using Unity.Entities;
using Unity.Mathematics;

namespace Components
{
    public struct Spawner : IComponentData
    {
        public Entity Prefab;
        public float3 SpawnPoint;
        public float NextSpawnTime;
        public float SpawnRate;
    }
}
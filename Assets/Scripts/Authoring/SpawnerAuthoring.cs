using Components;
using Unity.Entities;
using UnityEngine;

namespace Authoring
{
    public class SpawnerAuthoring : MonoBehaviour
    {
        public GameObject prefab;
        public float spawnRate;
        
        private class SpawnerAuthoringBaker : Baker<SpawnerAuthoring>
        {
            public override void Bake(SpawnerAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.None);
                AddComponent(entity, new Spawner()
                {
                    Prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
                    SpawnPoint = authoring.transform.position,
                    NextSpawnTime = 0.0f,
                    SpawnRate = authoring.spawnRate
                });
            }
        }
    }
}
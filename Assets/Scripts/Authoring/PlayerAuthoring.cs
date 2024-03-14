using Components;
using Unity.Entities;
using UnityEngine;

namespace Authoring
{
    public class PlayerAuthoring : MonoBehaviour
    {
        public float speed;
        public Vector3 direction;
        
        private class PlayerBaker : Baker<PlayerAuthoring>
        {
            public override void Bake(PlayerAuthoring authoring)
            {
                Entity entity = GetEntity(TransformUsageFlags.Dynamic);
                AddComponent(entity, new Player());
                AddComponent(entity, new SquareVelocity()
                {
                    Direction = authoring.direction,
                    Speed = authoring.speed
                });
            }
        }
    }
}
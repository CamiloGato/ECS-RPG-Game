using Components;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Systems
{
    public partial struct InputGetter : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            foreach ((RefRW<SquareVelocity> squareVelocity, RefRW<PlayerInput> playerInput) in SystemAPI.Query<RefRW<SquareVelocity>, RefRW<PlayerInput>>().WithAll<Player>())
            {
                playerInput.ValueRW.Horizontal = Input.GetAxis("Horizontal");
                playerInput.ValueRW.Vertical = Input.GetAxis("Vertical");
                playerInput.ValueRW.FireButton = Input.GetButtonDown("Fire1");
                squareVelocity.ValueRW.Direction = new float3(playerInput.ValueRO.Horizontal, playerInput.ValueRO.Vertical, 0);
            }
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
    }
}
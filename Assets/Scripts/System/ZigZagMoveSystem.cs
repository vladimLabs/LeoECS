using Leopotam.EcsLite;
using UnityEngine;

public sealed class ZigZagMoveSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _filter;
    private EcsPool<ZigZagMoveComponent> _pool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        _filter = world.Filter<ZigZagMoveComponent>().End();
        _pool = world.GetPool<ZigZagMoveComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        float dt = Time.deltaTime;

        foreach (var entity in _filter)
        {
            ref var move = ref _pool.Get(entity);

            move.Time += dt;
            
            Vector3 forwardMove = move.Direction * move.ForwardSpeed * dt;
            
            Vector3 side = Vector3.Cross(Vector3.up, move.Direction).normalized;

            float zigzag =
                Mathf.Sin(move.Time * move.Frequency + move.PhaseOffset)
                * move.Amplitude;

            Vector3 zigzagMove = side * zigzag;

            move.Transform.position += forwardMove + zigzagMove;
        }
    }
}
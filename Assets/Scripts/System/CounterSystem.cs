using Leopotam.EcsLite;

public sealed class CounterSystem : IEcsInitSystem, IEcsRunSystem
{
    private EcsFilter _filter;
    private EcsPool<CounterComponent> _pool;

    public void Init(IEcsSystems systems)
    {
        var world = systems.GetWorld();
        _filter = world.Filter<CounterComponent>().End();
        _pool = world.GetPool<CounterComponent>();
    }

    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _filter)
        {
            ref var counter = ref _pool.Get(entity);
            counter.Value++;
        }
    }
}
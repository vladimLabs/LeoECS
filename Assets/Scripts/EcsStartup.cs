using Leopotam.EcsLite;
using UnityEngine;

public class EcsStartup : MonoBehaviour
{
    private EcsWorld _world;
    private IEcsSystems _systems;

    [SerializeField] private ZigZagMoveProvider ballPrefab;
    [SerializeField] private int ballsCount = 1;

    private void Start()
    {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world);

        _systems
            .Add(new CounterSystem())
            .Add(new ZigZagMoveSystem())
            .Init();
        
        var counterEntity = _world.NewEntity();
        _world.GetPool<CounterComponent>().Add(counterEntity).Value = 0;
        
        for (int i = 0; i < ballsCount; i++)
        {
            var obj = Instantiate(
                ballPrefab,
                new Vector3(i * 2f, 0, 0),
                Quaternion.identity
            );
            
            obj.Convert(_world);
        }
    }

    private void Update()
    {
        _systems.Run();
    }

    private void OnDestroy()
    {
        _systems.Destroy();
        _world.Destroy();
    }
}
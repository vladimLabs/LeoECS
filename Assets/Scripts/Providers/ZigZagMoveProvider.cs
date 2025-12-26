using Leopotam.EcsLite;
using UnityEngine;

public class ZigZagMoveProvider : MonoBehaviour
{
    [SerializeField] private float forwardSpeed = 3f;
    [SerializeField] private float amplitude = 1f;
    [SerializeField] private float frequency = 3f;

    public void Convert(EcsWorld world)
    {
        var entity = world.NewEntity();
        ref var move = ref world.GetPool<ZigZagMoveComponent>().Add(entity);
        
        Vector2 randomDir2D = Random.insideUnitCircle.normalized;
        Vector3 direction = new Vector3(randomDir2D.x, 0f, randomDir2D.y);

        move.Transform = transform;
        move.Direction = direction;
        move.ForwardSpeed = forwardSpeed;

        move.Amplitude = amplitude;
        move.Frequency = frequency;
        move.PhaseOffset = Random.Range(0f, Mathf.PI * 2f);

        move.Time = 0f;
    }
}
using UnityEngine;

public struct ZigZagMoveComponent
{
    public Transform Transform;

    public Vector3 Direction;
    public float ForwardSpeed;

    public float Amplitude;
    public float Frequency;
    public float PhaseOffset;

    public float Time;
}
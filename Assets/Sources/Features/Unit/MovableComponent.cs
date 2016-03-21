using Entitas;
using UnityEngine;

public class MovableComponent : IComponent {
    public Vector2 velocity;
    public Vector2 maxVelocity;
    public Vector2 acceleration;
}

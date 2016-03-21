using UnityEngine;
using Entitas;
using System;
using DG.Tweening;

public class MoveSystem : IExecuteSystem, ISetPool
{
    Pool _pool;
    Group _movableEntities;

    Tween velocityTween;

    float _maxPlayerVelocity = 0.3f;
    float _minPlayerVelocity = 0.001f;

    public void Execute()
    {
        foreach (var e in _movableEntities.GetEntities())
        {
            if (e.movable.acceleration != Vector2.zero)
            {
                if (e.movable.acceleration.x + e.movable.velocity.x > e.movable.maxVelocity.x || e.movable.acceleration.x + e.movable.velocity.x < -e.movable.maxVelocity.x)
                    e.movable.velocity.x = Mathf.Sign(e.movable.velocity.x + e.movable.acceleration.x) * e.movable.maxVelocity.x;
                else
                    e.movable.velocity.x += e.movable.acceleration.x;

                if (e.movable.acceleration.y + e.movable.velocity.y > e.movable.maxVelocity.y || e.movable.acceleration.y + e.movable.velocity.y < -e.movable.maxVelocity.y)
                    e.movable.velocity.y = Mathf.Sign(e.movable.velocity.y + e.movable.acceleration.y) * e.movable.maxVelocity.y;
                else
                    e.movable.velocity.y += e.movable.acceleration.y;
            }
            
            e.movable.velocity = Vector2.Lerp(e.movable.velocity, e.movable.acceleration, Time.smoothDeltaTime*10.0f);
            
            e.position.coordinates += e.movable.velocity;
            e.view.model.transform.Translate(e.movable.velocity);

            e.movable.acceleration = Vector2.zero;
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _movableEntities = pool.GetGroup(Matcher.AllOf(Matcher.Position, Matcher.View, Matcher.Movable));
    }
}

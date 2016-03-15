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
            e.movable.velocity += e.movable.acceleration;

            if (Mathf.Abs(e.movable.acceleration.x) <_minPlayerVelocity && Mathf.Abs(e.movable.acceleration.y) < _minPlayerVelocity && (velocityTween == null || !velocityTween.IsPlaying()))
            {
                Debug.Log("Playing deccelerate tween");
                velocityTween = DOTween.To(() => e.movable.velocity, x => e.movable.velocity = x, Vector2.zero, 0.012f );
                velocityTween.Play();
            } else
            {
                velocityTween.Kill();
            }

            e.position.coordinates += e.movable.velocity;
            e.view.model.transform.position = e.position.coordinates;

            if (e.isPlayer && e.movable.velocity.magnitude > _maxPlayerVelocity)
                e.movable.velocity = e.movable.velocity.normalized* _maxPlayerVelocity;

            e.movable.acceleration = Vector2.zero;
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _movableEntities = pool.GetGroup(Matcher.AllOf(Matcher.Position, Matcher.View, Matcher.Movable));
    }
}

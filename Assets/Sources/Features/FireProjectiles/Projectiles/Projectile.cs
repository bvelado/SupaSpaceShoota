using UnityEngine;
using Entitas;

public abstract class Projectile
{
    protected abstract string _resource { get; }
    protected abstract float _baseVelocity { get; }
    protected abstract float _accelerationPower { get; }
    protected abstract int _damage { get; }

    protected abstract bool _isFriendly { get; }

    public void Launch(Pool pool, Vector2 power, Vector2 position)
    {
        var e = pool.CreateEntity()
            .AddResource(_resource)
            .AddPosition(position)
            .AddMovable(Vector2.zero, new Vector2(2f,1f),power);
        if (_damage != 0)
            e.AddDamageable(_damage);
        if (_isFriendly)
            e.IsFriendly(true);
    }
}

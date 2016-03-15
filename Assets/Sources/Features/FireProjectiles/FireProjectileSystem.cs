using System;
using System.Collections.Generic;
using Entitas;

public class FireProjectileSystem : IReactiveSystem, ISetPool
{
    Pool _pool;
    Group _fireableProjectiles;

    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Input.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            if (e.input.intent == InputIntent.Fire && _fireableProjectiles.count > 0)
            {
                if (_fireableProjectiles.GetEntities()[0].carriable.amout > 0)
                {
                    _fireableProjectiles.GetEntities()[0].projectile.baseProjectile.Launch(_pool, ((Entity)e.input.data[0]).view.model.transform.up, ((Entity)e.input.data[0]).position.coordinates);
                    _fireableProjectiles.GetEntities()[0].carriable.amout--;
                }
                e.IsDestroy(true);
            }
        }
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
        _fireableProjectiles = pool.GetGroup(Matcher.AllOf(Matcher.Projectile, Matcher.Carriable, Matcher.Fireable));
    }
}

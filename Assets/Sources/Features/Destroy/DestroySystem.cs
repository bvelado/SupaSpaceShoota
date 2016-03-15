using System;
using System.Collections.Generic;
using Entitas;

public class DestroySystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Destroy.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            e.RemoveAllComponents();
            foreach(Pool pool in Pools.allPools)
            {
                pool.DestroyEntity(e);
            }
        }
    }
}

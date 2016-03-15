using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class RemoveViewSystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Resource.OnEntityRemoved();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            GameObject.Destroy(e.view.model);
        }
    }
}

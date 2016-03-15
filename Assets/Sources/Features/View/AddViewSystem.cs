using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class AddViewSystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Resource.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            GameObject go = GameObject.Instantiate(Resources.Load<GameObject>(e.resource.path));
            e.AddView(go);
        }
    }
}

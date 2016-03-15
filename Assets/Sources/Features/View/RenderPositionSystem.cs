using UnityEngine;
using Entitas;
using System;
using System.Collections.Generic;

public class RenderPositionSystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.AllOf(Matcher.View, Matcher.Position).OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach(var e in entities)
        {
            e.view.model.transform.position = e.position.coordinates;
        }
    }
}

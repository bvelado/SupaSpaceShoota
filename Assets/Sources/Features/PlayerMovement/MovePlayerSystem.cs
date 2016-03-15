using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class MovePlayerSystem : IReactiveSystem
{
    public TriggerOnEvent trigger
    {
        get
        {
            return Matcher.Input.OnEntityAdded();
        }
    }

    public void Execute(List<Entity> entities)
    {
        foreach (var e in entities)
        {
            if (e.input.intent == InputIntent.Move)
            {
                Entity playerEntity = e.input.data[0] as Entity;
                if (playerEntity.isPlayer && playerEntity.hasPosition && playerEntity.hasMovable)
                {
                    playerEntity.movable.acceleration = ((Vector3)e.input.data[1]);
                }

                e.IsDestroy(true);
            }
        }
    }
}

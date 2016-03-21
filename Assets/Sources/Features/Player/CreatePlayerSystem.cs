using UnityEngine;
using Entitas;
using System;

public class CreatePlayerSystem : IInitializeSystem, ISetPool
{
    Pool _pool;

    public void Initialize()
    {
        _pool.CreateEntity()
            .IsPlayer(true)
            .AddResource("Prefabs/Player")
            .AddPosition(Vector2.zero)
            .AddMovable(Vector2.zero, new Vector2(0.3f,0.1f), Vector2.zero);
    }

    public void SetPool(Pool pool)
    {
        _pool = pool;
    }
}

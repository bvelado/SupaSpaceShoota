using UnityEngine;
using Entitas;
using Entitas.Unity.VisualDebugging;
using DG.Tweening;

public class GameController : MonoBehaviour {

    Systems _systems;

	// Use this for initialization
	void Start () {
        DOTween.Init();

        _systems = CreateSystems(Pools.pool);

        _systems.Initialize();
	}
	
	// Update is called once per frame
	void Update () {
        _systems.Execute();
	}

    Systems CreateSystems(Pool pool)
    {
#if UNITY_EDITOR
        return new DebugSystems()
#else
            return new Systems()
#endif
            .Add(pool.CreateSystem<CreatePlayerSystem>())
            .Add(pool.CreateSystem<AddViewSystem>())
            .Add(pool.CreateSystem<RemoveViewSystem>())

            .Add(pool.CreateSystem<FireProjectileSystem>())
            .Add(pool.CreateSystem<MovePlayerSystem>())

            .Add(pool.CreateSystem<MoveSystem>())
            .Add(pool.CreateSystem<RenderPositionSystem>())

            
            
            .Add(pool.CreateSystem<DestroySystem>());
    }
}

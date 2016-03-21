using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
    Vector2 movementInput;

    void Start()
    {
        Pools.pool.CreateEntity().AddProjectile(new SimpleProjectile()).AddCarriable(10).IsFireable(true);
    }

	void Update () {
	    if(Input.GetButtonDown("Jump"))
        {
            Pools.pool.CreateEntity().AddInput(InputIntent.Fire, new object[] { Pools.pool.playerEntity });
        }

        movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movementInput != Vector2.zero)
            Pools.pool.CreateEntity().AddInput(InputIntent.Move, new object[] { Pools.pool.playerEntity, movementInput });
	}
}

using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour {
    Vector3 movementInput;

    void Start()
    {
        Pools.pool.CreateEntity().AddProjectile(new SimpleProjectile()).AddCarriable(10).IsFireable(true);
    }

	void Update () {
	    if(Input.GetButtonDown("Jump"))
        {
            Pools.pool.CreateEntity().AddInput(InputIntent.Fire, new object[] { Pools.pool.playerEntity });
        }

        movementInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (movementInput != Vector3.zero)
            Pools.pool.CreateEntity().AddInput(InputIntent.Move, new object[] { Pools.pool.playerEntity, movementInput*0.01f });
	}
}

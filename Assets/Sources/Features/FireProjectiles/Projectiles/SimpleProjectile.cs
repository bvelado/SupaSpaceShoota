using UnityEngine;
using System.Collections;
using System;

public class SimpleProjectile : Projectile {

    protected override string _resource
    {
        get
        {
            return "Prefabs/Projectile";
        }
    }

    protected override float _accelerationPower
    {
        get
        {
            return 1.0f;
        }
    }

    protected override float _baseVelocity
    {
        get
        {
            return 0.01f;
        }
    }

    protected override int _damage
    {
        get
        {
            return 10;
        }
    }

    protected override bool _isFriendly
    {
        get
        {
            return false;
        }
    }

    
}

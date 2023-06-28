using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akm : Weapon
{
    public override void Reload()
    {

    }

    public override void Shoot()
    {
        Bullet bullet = Instantiate(Prefab,ShootPointPosition.position,transform.rotation);
    }
}

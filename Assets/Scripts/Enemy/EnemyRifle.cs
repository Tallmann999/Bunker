using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRifle : Weapon
{
    public override void Reload()
    {
    }

    public override void Shoot()
    {
        Bullet bullet = Instantiate(Prefab, ShootPointPosition.position, ShootPointPosition.rotation);
    }
}

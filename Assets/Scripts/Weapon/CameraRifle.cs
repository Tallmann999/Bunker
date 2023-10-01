using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRifle : Weapon
{
    public override void Reload() { }

    public override void Shoot()
    {
        AudioSource.PlayOneShot(OneShot);
        CreateSleeve();
        Bullet bullet = Instantiate(Prefab, ShootPointPosition.position, transform.rotation);
    }
    private void CreateSleeve()
    {
        Sleeve sleeve = Instantiate(BulletTipsPrefabs, DropTips.position, transform.rotation);
        AudioSource.PlayOneShot(SleeveDrop);
    }
}

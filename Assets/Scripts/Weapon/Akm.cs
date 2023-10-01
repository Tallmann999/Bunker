using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akm : Weapon
{
    [SerializeField] private int _currentMagazineBulletsCount;
    [SerializeField] private int _maxBullet;
    [SerializeField] private int _magazineSize;
    [SerializeField] private float _reloadLastTime;
     

    private void Start()
    {
        MaxBullet = _maxBullet;
        ÑurrentMagazineBulletsCount = _magazineSize;
        AudioSource = GetComponent<AudioSource>();
    }

    public override void Reload()
    {
    
    }

    public override void Shoot()
    {
        AudioSource.PlayOneShot(OneShot);
        CreateSleeve();
        Bullet bullet = Instantiate(Prefab,ShootPointPosition.position,transform.rotation);
    }
    private void CreateSleeve()
    {
       Sleeve sleeve = Instantiate(BulletTipsPrefabs, DropTips.position, transform.rotation);
        AudioSource.PlayOneShot(SleeveDrop);
    }
}

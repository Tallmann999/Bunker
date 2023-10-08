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
        int remainBulletCount = 0;

        if (MaxBullet > 0)
        {
            if (ÑurrentMagazineBulletsCount == 0)
            {
                MaxBullet -= _magazineSize;
                AudioSource.PlayOneShot(Reloading);
                ÑurrentMagazineBulletsCount = _magazineSize;
            }
            else
            {
                if (MaxBullet < ÑurrentMagazineBulletsCount)
                {
                    remainBulletCount = _magazineSize - ÑurrentMagazineBulletsCount;

                    if (MaxBullet >= remainBulletCount)
                    {
                        MaxBullet -= remainBulletCount;
                        AudioSource.PlayOneShot(Reloading);
                        ÑurrentMagazineBulletsCount += remainBulletCount;
                    }
                    else
                    {
                        ÑurrentMagazineBulletsCount += MaxBullet;
                        AudioSource.PlayOneShot(Reloading);
                        MaxBullet = 0;
                    }
                }
                else
                {
                    remainBulletCount = _magazineSize - ÑurrentMagazineBulletsCount;
                    MaxBullet -= remainBulletCount;
                    AudioSource.PlayOneShot(Reloading);
                    ÑurrentMagazineBulletsCount += remainBulletCount;
                }
            }
        }
        else
        {
            Debug.Log("Ïàòðîíû êîí÷èëèñü");
        }
    }

    public override void Shoot()
    {
        if (ÑurrentMagazineBulletsCount > 0)
        {
            AudioSource.PlayOneShot(OneShot);
            CreateSleeve();
            Bullet bullet = Instantiate(Prefab, ShootPointPosition.position, transform.rotation);
            ÑurrentMagazineBulletsCount--;

        }
        else
        {
            Reload();
        }

    }
    private void CreateSleeve()
    {
       Sleeve sleeve = Instantiate(BulletTipsPrefabs, DropTips.position, transform.rotation);
        AudioSource.PlayOneShot(SleeveDrop);
    }
}

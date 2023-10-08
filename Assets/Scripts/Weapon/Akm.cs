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
        �urrentMagazineBulletsCount = _magazineSize;
        AudioSource = GetComponent<AudioSource>();
    }

    public override void Reload()
    {
        int remainBulletCount = 0;

        if (MaxBullet > 0)
        {
            if (�urrentMagazineBulletsCount == 0)
            {
                MaxBullet -= _magazineSize;
                AudioSource.PlayOneShot(Reloading);
                �urrentMagazineBulletsCount = _magazineSize;
            }
            else
            {
                if (MaxBullet < �urrentMagazineBulletsCount)
                {
                    remainBulletCount = _magazineSize - �urrentMagazineBulletsCount;

                    if (MaxBullet >= remainBulletCount)
                    {
                        MaxBullet -= remainBulletCount;
                        AudioSource.PlayOneShot(Reloading);
                        �urrentMagazineBulletsCount += remainBulletCount;
                    }
                    else
                    {
                        �urrentMagazineBulletsCount += MaxBullet;
                        AudioSource.PlayOneShot(Reloading);
                        MaxBullet = 0;
                    }
                }
                else
                {
                    remainBulletCount = _magazineSize - �urrentMagazineBulletsCount;
                    MaxBullet -= remainBulletCount;
                    AudioSource.PlayOneShot(Reloading);
                    �urrentMagazineBulletsCount += remainBulletCount;
                }
            }
        }
        else
        {
            Debug.Log("������� ���������");
        }
    }

    public override void Shoot()
    {
        if (�urrentMagazineBulletsCount > 0)
        {
            AudioSource.PlayOneShot(OneShot);
            CreateSleeve();
            Bullet bullet = Instantiate(Prefab, ShootPointPosition.position, transform.rotation);
            �urrentMagazineBulletsCount--;

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

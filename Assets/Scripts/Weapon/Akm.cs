using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Akm : Weapon
{
    [SerializeField] private int _magazineSize;
    [SerializeField] private float _reloadLastTime;

    public override void AddAmmoBox(int ammoCount)
    {
        MaxBullet = MaxBullet + ammoCount;
    }

    public override void Reload()
    {
        int remainBulletCount = 0;

        if (MaxBullet > 0)
        {
            if (ŅurrentMagazineBulletsCount == 0)
            {
                MaxBullet -= _magazineSize;
                AudioSource.PlayOneShot(Reloading);
                ŅurrentMagazineBulletsCount = _magazineSize;
            }
            else
            {
                if (MaxBullet < ŅurrentMagazineBulletsCount)
                {
                    remainBulletCount = _magazineSize - ŅurrentMagazineBulletsCount;

                    if (MaxBullet > remainBulletCount)
                    {
                        MaxBullet -= remainBulletCount;
                        AudioSource.PlayOneShot(Reloading);
                        ŅurrentMagazineBulletsCount += remainBulletCount;
                    }
                    else
                    {
                        ŅurrentMagazineBulletsCount += MaxBullet;
                        AudioSource.PlayOneShot(Reloading);
                        MaxBullet = 0;
                    }
                }
                else
                {
                    remainBulletCount = _magazineSize - ŅurrentMagazineBulletsCount;
                    MaxBullet -= remainBulletCount;
                    AudioSource.PlayOneShot(Reloading);
                    ŅurrentMagazineBulletsCount += remainBulletCount;
                }
            }
        }
        else
        {
            AudioSource.PlayOneShot(EmptyMagazine);
        }
    }

    public override void Shoot()
    {
        if (ŅurrentMagazineBulletsCount > 0)
        {
            AudioSource.PlayOneShot(OneShot);
            CreateSleeve();
            Bullet bullet = Instantiate(Prefab, ShootPointPosition.position, transform.rotation);
            ŅurrentMagazineBulletsCount--;
        }
        else
        {
            Reload();
        }
    }

    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    private void CreateSleeve()
    {
        Sleeve sleeve = Instantiate(BulletTipsPrefabs, DropTips.position, transform.rotation);
        AudioSource.PlayOneShot(SleeveDrop);
    }
}

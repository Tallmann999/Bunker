using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string Label;
    [SerializeField] protected Sprite Icon;

    [SerializeField] public  int MaxBullet;
    [SerializeField] public  int ÑurrentMagazineBulletsCount;

    [SerializeField] protected Bullet Prefab;
    [SerializeField] protected Sleeve BulletTipsPrefabs;
    [SerializeField] protected Transform ShootPointPosition;
    [SerializeField] protected Transform DropTips;

    [SerializeField] protected AudioSource AudioSource;
    [SerializeField] protected AudioClip OneShot;
    [SerializeField] protected AudioClip SleeveDrop;
    [SerializeField] protected AudioClip Reloading;

    public abstract void Shoot();
    public abstract void Reload();
}

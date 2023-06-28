using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected string Label;
    //[SerializeField] protected TextMeshProUGUI NameWeapon; ItemView
    [SerializeField] private Sprite _icon;
    //[SerializeField] private int _price; если будет магазин. Лучше просто брать пистолет

    [SerializeField] protected int MagazineSize;
    [SerializeField] protected int СurrentMagazineBulletsCount;
    [SerializeField] protected int MaxBullet;
    [SerializeField] protected float ReloadLastTime;
    //[SerializeField] protected TextMeshProUGUI MagazineBulletsCount;
    //[SerializeField] protected TextMeshProUGUI MaxBulletsCount;

    [SerializeField] protected Bullet Prefab;
    [SerializeField] protected GameObject BulletTips;
    [SerializeField] protected Transform ShootPointPosition;
    [SerializeField] protected ParticleSystem ShootEffect;

    public  abstract void Shoot();
    public abstract void Reload();
}

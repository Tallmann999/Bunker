using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponView : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI MagazineBulletsCount;
    [SerializeField] protected TextMeshProUGUI MaxBulletsCount;
    [SerializeField] private Weapon _currentWeapon;

    private void Start()
    {
        _currentWeapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        BulletsInformation();
    }

    public void BulletsInformation()
    {
        MagazineBulletsCount.text = _currentWeapon.ÑurrentMagazineBulletsCount.ToString();
        MaxBulletsCount.text = _currentWeapon.MaxBullet.ToString();
    }
}

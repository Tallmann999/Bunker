using TMPro;
using UnityEngine;

public class WeaponView : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI MagazineBulletsCount;
    [SerializeField] protected TextMeshProUGUI MaxBulletsCount;
    [SerializeField] private Weapon _currentWeapon;

    public void BulletsInformation()
    {
        MagazineBulletsCount.text = _currentWeapon.ÑurrentMagazineBulletsCount.ToString();
        MaxBulletsCount.text = _currentWeapon.MaxBullet.ToString();
    }

    private void Start()
    {
        _currentWeapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        BulletsInformation();
    }
}

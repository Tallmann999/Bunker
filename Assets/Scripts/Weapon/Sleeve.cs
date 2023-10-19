using UnityEngine;

public class Sleeve : MonoBehaviour
{
    private float _lifetime = 1f;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}

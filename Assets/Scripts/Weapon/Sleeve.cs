using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleeve : MonoBehaviour
{
    private float _lifetime = 1f;

    void Start()
    {
        Destroy(gameObject, _lifetime);
    }
}

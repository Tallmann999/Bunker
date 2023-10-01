using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWeapon : MonoBehaviour
{
    [SerializeField] private float _offset;
    [SerializeField] private PlayerMover _playerMover;

    private Vector3 _localScale;

    private void Update()
    {
        Vector3 diferrents = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diferrents.y, diferrents.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);

         _localScale = Vector3.one;

        if (rotateZ > 90 || rotateZ < -90)
        {
            _playerMover.FlipFromWeapon(false);
            _localScale.y = -1f;
        }
        else
        {
            _playerMover.FlipFromWeapon(true);

            _localScale.y = 1f;
        }

        transform.localScale = _localScale;
    }
}

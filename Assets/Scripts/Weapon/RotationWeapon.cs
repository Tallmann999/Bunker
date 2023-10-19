using UnityEngine;

public class RotationWeapon : MonoBehaviour
{
    [SerializeField] private PlayerMover _playerMover;
    [SerializeField] private float _offset;

    private Vector3 _localScale;
    private int _rotationAngle = 90;
    private float _rotationY = 1f;

    private void Update()
    {
        Vector3 diferrents = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(diferrents.y, diferrents.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + _offset);
        _localScale = Vector3.one;

        if (rotateZ > _rotationAngle || rotateZ < -_rotationAngle)
        {
            _playerMover.FlipFromWeapon(false);
            _localScale.y = -_rotationY;
        }
        else
        {
            _playerMover.FlipFromWeapon(true);

            _localScale.y = _rotationY;
        }

        transform.localScale = _localScale;
    }
}

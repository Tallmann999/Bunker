using System.Collections;
using UnityEngine;
using UnityEngine.Events;
public class EnemyRotateDetector : MonoBehaviour
{
    [SerializeField] private Transform _rayDirection;
    [SerializeField] private float _rotationCicleSpeed;
    [SerializeField] private float _maxRotationAngle;
    [SerializeField] private float _minRotationAngle;

    public event UnityAction<bool> OnShoot;

    private Coroutine _activeCorutine = null;
    private bool _isRotation = true;
    private float _lazerLength = 7f;
    private void Start()
    {
        if (_activeCorutine != null)
        {
            StopCoroutine(_activeCorutine);
        }

        _activeCorutine = StartCoroutine(RotateAround());
    }

    private IEnumerator RotateAround()
    {
        while (_isRotation)
        {
            float rotation = Mathf.PingPong(Time.time * _rotationCicleSpeed, _maxRotationAngle - _minRotationAngle)
                + _minRotationAngle;
            transform.rotation = Quaternion.Euler(0, 0, rotation);
            LazerDetection();
            yield return null;
        }
    }

    private void LazerDetection()
    {
        RaycastHit2D hit = Physics2D.Raycast(_rayDirection.position, _rayDirection.TransformDirection(Vector3.down), _lazerLength);

        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Player player))
        {
            OnShoot?.Invoke(true);
            _isRotation = false;
        }
    }
}




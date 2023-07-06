using UnityEngine;

public class DistansTransition : Transition
{
    [SerializeField] private MoveState _enemy;
    [SerializeField] private Transform _detectorRay;
    [SerializeField] private float _detectionDistance = 5f;
    [SerializeField] private LayerMask _detectionLayer;
    [SerializeField] private Animator _animator;

    public bool RotateStatus;

    private void Update()
    {
        Vector2 direction = RotateStatus ==false ? Vector2.left : Vector2.right;
        Ray2D ray = new Ray2D(_detectorRay.position, direction);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, _detectionDistance, _detectionLayer);

        if (hit.collider != null)
        {
            NeedTransit = true;
        }
        Debug.Log(RotateStatus);

        Debug.DrawRay(ray.origin, ray.direction * _detectionDistance, Color.red);
    }

    private void OnEnable()
    {
        _enemy.RightMove += NeedRotate;
    }

    private void OnDisable()
    {
        _enemy.RightMove -= NeedRotate;

    }

    private void NeedRotate(bool rotate)
    {
        RotateStatus = rotate;
    }


}

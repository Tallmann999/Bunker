using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerMover))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMover _mover;
    private Player _player;

    private void Start()
    {
        _mover = GetComponent<PlayerMover>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        MoveControl();
        JumpControl();
        WeaponInput();
    }

    private void WeaponInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_mover.IsLadder == false)
            {
                _player.CurrentWeapon.Shoot();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (_mover.IsLadder == false)
            {
                _player.CurrentWeapon.Reload();
            }
        }
    }

    private void JumpControl()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _mover.IsGrounded && _mover.IsMoving)
        {
            _mover.AnimationJump();
        }
    }

    private void MoveControl()
    {
        const string Horizontal = "Horizontal";

        _mover.AnimationMove(Input.GetAxis(Horizontal));
    }
}

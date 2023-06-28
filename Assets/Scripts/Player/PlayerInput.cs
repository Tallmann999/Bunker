using System;
using System.Collections;
using System.Collections.Generic;
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
        Attack();
    }

    private void Attack()
    {
        const string Fire = "Fire1";

        if (Input.GetMouseButtonDown(0))
        {
            _player.CurrentWeapon.Shoot();
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

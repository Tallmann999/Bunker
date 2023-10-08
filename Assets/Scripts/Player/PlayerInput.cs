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

        if (Input.GetMouseButtonDown(2))
        {
            _player.PreviesWeapon();// не проверял следующее оружие.
            Debug.Log("Меняет следующее оружие");
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

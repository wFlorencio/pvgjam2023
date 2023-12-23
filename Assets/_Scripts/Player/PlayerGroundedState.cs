using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.canDoubleJump = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.J))
            stateMachine.ChangeState(player.PrimaryAttack);

        // Carregando o tiro...
        if (Input.GetKey(KeyCode.F) && player.abilities.canUseBow)
        {
            player.isCharging = true;
            if (player.isCharging)
            {
                player.chargeTime += Time.deltaTime * player.chargeSpeed;
            }
        }

        if (Input.GetKeyUp(KeyCode.F) && player.abilities.canUseBow)
        {
            stateMachine.ChangeState(player.ShotState);
        }


        if (!player.IsGroundDetected())
            stateMachine.ChangeState(player.AirState);

        if (Input.GetAxisRaw("Vertical") >= 0 && Input.GetKeyDown(KeyCode.Space) && (player.IsGroundDetected()))
        {
            // For sensitive jump logic...
            player.isJumping = true;
            player.jumpTime = player.jumpStartTime;
            player.JumpButton();
        }

        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
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

        // if (player.IsWallDetected())
           // stateMachine.ChangeState(player.WallSlide);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.IdleState);

        if (xInput != 0)
            player.SetVelocity(player.moveSpeed * 1f * xInput, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.J))
            stateMachine.ChangeState(player.PrimaryAttack);

        if (Input.GetKeyDown(KeyCode.Space) && player.canDoubleJump && player.abilities.canDoubleJump)
        {
            player.canDoubleJump = false;
            rb.velocity = new Vector2(rb.velocity.x, 15);
        }
    }
}

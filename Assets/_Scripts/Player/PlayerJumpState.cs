using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    public PlayerJumpState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        rb.velocity = new Vector2(rb.velocity.x, player.jumpForce);
        player.canDoubleJump = true;
        player.isJumping = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (xInput != 0)
            player.SetVelocity(player.moveSpeed * 1f * xInput, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.J))
            stateMachine.ChangeState(player.PrimaryAttack);

        if (rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.AirState);
        }

        if (player.isJumping)
        {
            if (player.jumpTime > 0)
            {
                stateMachine.ChangeState(player.JumpState);
                player.jumpTime -= Time.deltaTime;
            }
            else
            {
                player.isJumping = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.isJumping = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && player.canDoubleJump && player.abilities.canDoubleJump)
        {
            player.canDoubleJump = false;
            rb.velocity = new Vector2(rb.velocity.x, 15);
        }
    }
}

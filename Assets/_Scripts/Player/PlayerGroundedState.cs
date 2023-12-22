using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _playerStateMachine, string _animBoolName) : base(_player, _playerStateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
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

        if (Input.GetKeyDown(KeyCode.Mouse1) && player.abilities.canUseBow)
            stateMachine.ChangeState(player.ShotState);

        if (!player.IsGroundDetected())
            stateMachine.ChangeState(player.AirState);

        if (Input.GetAxisRaw("Vertical") >= 0 && Input.GetKeyDown(KeyCode.Space) && (player.IsGroundDetected()))
        {
            stateMachine.ChangeState(player.JumpState);
        }



            
    }
}

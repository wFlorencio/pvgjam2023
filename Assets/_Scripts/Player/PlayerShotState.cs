using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotState : PlayerState
{
    public PlayerShotState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        
        stateTimer = player.shotDuration;
        
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if (stateTimer < 0)
        {
            stateMachine.ChangeState(player.IdleState);
        }

        player.ZeroVelocity();
    }
}

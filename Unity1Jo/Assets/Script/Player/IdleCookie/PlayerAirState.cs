using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAirState : PlayerState
{
    public PlayerAirState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKey(KeyCode.S)) // ����
        {
            player.stateMachine.ChangeState(player.slideState);

        }
        else if (player.IsGroundDetected())// ���� ���� �۵��ϸ� ������
        {
            stateMachine.ChangeState(player.idleState);
        }

        if (player.IsWallDetected())
        {
            player.stateMachine.ChangeState(player.hitState);
        }

        if (player.isBonusTime)
        {

            player.stateMachine.ChangeState(player.highState);
            player.SetActiveShinyEffect(true);
            player.GetShinyEffect()?.GetComponent<ShinyEffect>().StartRotateLightsEffect();
        }
    }

    public override void Exit()
    {
        base.Exit();
        player.vibrate();
    }

    
}

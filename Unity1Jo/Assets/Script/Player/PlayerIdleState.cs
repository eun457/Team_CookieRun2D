using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{

    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space) && player.IsGroundDetected()) // ����
            player.stateMachine.ChangeState(player.jumpState);

        if (Input.GetKeyDown(KeyCode.Space) && !player.IsGroundDetected()) // �߰�
            player.stateMachine.ChangeState(player.doubleJumpState);

        if (Input.GetKeyDown(KeyCode.S) && player.IsGroundDetected()) // ����
            player.stateMachine.ChangeState(player.slideState);

        //if (Input.GetKeyDown(KeyCode.D))
        //    player.stateMachine.ChangeState(player.dashState);

        //if (Input.GetKeyDown(KeyCode.G))
        //    player.stateMachine.ChangeState(player.giganticState);

        if (Input.GetKeyDown(KeyCode.D))
            player.stateMachine.ChangeState(player.deathState);

        if (Input.GetKeyDown(KeyCode.H))
        {
            player.stateMachine.ChangeState(player.highState);
            player.SetActiveShinyEffect(true);
            player.GetShinyEffect()?.GetComponent<ShinyEffect>().StartRotateLightsEffect();        
        }

        if (Input.GetKeyDown(KeyCode.F))
            player.stateMachine.ChangeState(player.fallingState);  
    }

    public override void Exit()
    {
        base.Exit();
    }
}

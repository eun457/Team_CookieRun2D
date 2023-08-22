using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : PlayerState
{
    public PlayerDoubleJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();


        Vector2 jumpVec = new Vector2(rb.velocity.x, player.jumpPower);

        rb.velocity = jumpVec; // AddForce���� ���ͷ� ���� �ִ� �������� ������ �� ���� �ö��� �ʾ���.
    }

    public override void Update()
    {
        base.Update();

        if(rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.airState);
        }
    }

    public override void Exit()
    {
        base.Exit();

    }

}

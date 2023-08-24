using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonusUpState : PlayerState
{
    public PlayerBonusUpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    // code by ��ȣ
    public override void Enter()
    {
        base.Enter();
        rb.gravityScale = 1;
        Vector2 jumpVec = new Vector2(0, 5);      
        rb.AddForce(jumpVec, ForceMode2D.Impulse);
        stateMachine.ChangeState(player.bonusDownState);      
    }
    // code by ��ȣ
    public override void Exit()
    {
        base.Exit();
        rb.gravityScale = 0;  
    }
    // code by ��ȣ
    public override void Update()
    {
        base.Update();

    }
}

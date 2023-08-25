using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonusDownState : PlayerState
{
    public PlayerBonusDownState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }
    // code by ��ȣ
    public override void Enter()
    {
        base.Enter(); // �θ��� Enter �Լ� ���� 
        //rb.gravityScale = 0.5f; // �߷��� 1���� �ݵ� 
        player.SetVelocity(0, -player.bonusJumpPower);

    }
    // code by ��ȣ
    public override void Exit()
    {
        base.Exit(); // �θ��� Exit �Լ� ���� 
    }
    // code by ��ȣ
    public override void Update()
    {
        base.Update();  // �θ��� Update �Լ� ���� 

    }
}

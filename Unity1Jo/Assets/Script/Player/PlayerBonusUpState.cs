using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBonusUpState : PlayerState
{
    public PlayerBonusUpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName) // ������ 
    {

    }
    // code by ��ȣ
    public override void Enter()
    {
        base.Enter(); // �θ��� Enter �Լ� ���� 
        player.rb.gravityScale = 0; // �߷��� 0���� �ݵ�   

    }
    // code by ��ȣ
    public override void Exit()
    {
        base.Exit(); // �θ��� Exit �Լ� ���� 

    }
    // code by ��ȣ
    public override void Update()
    {
        base.Update(); // �θ��� Update �Լ� ���� 
        if (!player.isBonusTime)
        {
            stateMachine.ChangeState(player.fallingState);
        }
    }
}

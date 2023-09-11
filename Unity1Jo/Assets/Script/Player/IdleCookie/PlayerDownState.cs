using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDownState : PlayerState
{
    public PlayerDownState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    // code by ��ȣ
    public override void Enter()
    {
        base.Enter(); // �θ��� Enter �Լ� ����   

        float time = player.downTime;

        if (player.middlePos != null) // null �� �ƴ��� üũ 
            player.transform.DOMoveY(player.middlePos.transform.position.y, time).OnComplete(
                () => {
                    // �߾� ��ġ���� �̵��� �������� downState�� �̵� 
                    stateMachine.ChangeState(player.bonusDownState);
                }); ;      // �߾� ��ġ�� �̵� 
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
        player.DestrtoyObject();  

    }
}

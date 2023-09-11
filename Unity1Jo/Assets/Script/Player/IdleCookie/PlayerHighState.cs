using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class PlayerHighState : PlayerState
{
   

    public PlayerHighState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    // code by ��ȣ
    public override void Enter()
    {
        base.Enter(); // �θ��� Enter �Լ� ���� 
        player.DestrtoyObject();  

        ingameuiManager.HpDown = false;  

        float time = player.topTime; 

        if (player.topPos != null)
            player.transform.DOMoveY(player.topPos.transform.position.y, time).OnComplete(
                () => {
                    // �ִ� ��ġ���� �̵��� �������� downState�� �̵�
                    EnvironmentManager.Instance.SetActiveInGameEnvironment(false);
                    EnvironmentManager.Instance.SetActiveBonusTimeEnvironment(true);  

                    stateMachine.ChangeState(player.downState);
                });

       // Spawnanager.Instance.GetComponent<Spawnanager>().enabled = false;  
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
        player.DestrtoyObject();  
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    public PlayerFallingState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter(); // �θ��� Enter �Լ� ���� 
        rb.gravityScale = 5; // �߷��� 1���� �ݵ�  //�߷°� �ٲ� �߷°��� 5�� ��������ϴ�.

        player.isBonusStart = false;

        EnvironmentManager.Instance.GetBonusMap().GetComponent<BonusMap>().SetBonusWallColliderEnabled(false);  // ���ʽ� ���� ���� collider enabled false
        TransitionController.Play(Define.Transition.Fade);    //fade in out 

        EnvironmentManager.Instance.SetActiveInGameEnvironment(true);
        EnvironmentManager.Instance.SetActiveBonusTimeEnvironment(false);

        player.StartCoroutine("CoSetPlayerScreenOutTopPos");    
        //player.transform.GetComponent<Rigidbody2D>().gravityScale = 5;


    }


    public override void Exit()
    {
        base.Exit(); // �θ��� Exit �Լ� ���� 
        EnvironmentManager.Instance.GetBonusMap().GetComponent<BonusMap>().SetBonusWallColliderEnabled(true);
        rb.gravityScale = 5; // �߷��� 1���� �ݵ�  //�߷°� �ٲ� �߷°��� 5�� ��������ϴ�.


    }

    public override void Update()
    {
        base.Update();// �θ��� Update �Լ� ���� 

        if (player.IsGroundDetected() == true)
            player.stateMachine.ChangeState(player.idleState);  

    }
}

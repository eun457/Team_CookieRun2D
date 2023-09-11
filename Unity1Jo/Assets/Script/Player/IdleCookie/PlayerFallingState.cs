using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    Player p;
    //����
    string bgmAudioClipPath1 = "BGM_Map1";
    string bgmAudioClipPath2 = "BGM_Map2";
    public PlayerFallingState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
        p= _player;
    }
    //public void Awake()
    //{
    //    p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    //}

    public override void Enter()
    {
        base.Enter(); // �θ��� Enter �Լ� ���� 
        rb.gravityScale = 5; // �߷��� 1���� �ݵ�  //�߷°� �ٲ� �߷°��� 5�� ��������ϴ�.

        player.isBonusStart = false;

        EnvironmentManager.Instance.GetBonusMap().GetComponent<BonusMap>().SetBonusWallColliderEnabled(false);  // ���ʽ� ���� ���� collider enabled false
        BonusTime_FadeInOut.Play(Define.Transition.Fade);    //fade in out 

        
        //EnvironmentManager.Instance.GetInGameMap().transform.position = new Vector2(-25, 0);          
        //EnvironmentManager.Instance.GetBonusMap().transform.position = new Vector2(-20, 0);          
        player.StartCoroutine("CoSetPlayerScreenOutTopPos");
        //player.transform.GetComponent<Rigidbody2D>().gravityScale = 5;
        GameObject.Find("InGameUI").GetComponent<UI_IngameBtn>().SetButtonPush(false);

        // bonus ���ĺ� �ʱ�ȭ 
        player.GetComponent<PlayerBonusTimeCount>().ClearBonusAlphaBetCount();  

        //BGM���
        if (p.mapcount == 0)
        {
            Debug.Log("1�� �뷡");
            AudioClip bgmAudioClip1 = GameManager.Instance.LoadAudioClip(bgmAudioClipPath1);
            if (bgmAudioClip1 != null)
                SoundManager.Instance.Play(bgmAudioClip1, Define.Sound.Bgm);
        }
        else if(p.mapcount == 1)
        {
            Debug.Log("2�� �뷡");
            AudioClip bgmAudioClip2 = GameManager.Instance.LoadAudioClip(bgmAudioClipPath2);
            if (bgmAudioClip2 != null)
                SoundManager.Instance.Play(bgmAudioClip2, Define.Sound.Bgm);
        }


    }


    public override void Exit()
    {
        base.Exit(); // �θ��� Exit �Լ� ���� 
        
        EnvironmentManager.Instance.GetBonusMap().GetComponent<BonusMap>().SetBonusWallColliderEnabled(true);
        rb.gravityScale = 5; // �߷��� 1���� �ݵ�  //�߷°� �ٲ� �߷°��� 5�� ��������ϴ�.
        PlayerManager.Instance.SetOriginPlayerPositi2on();
        //player.isBonusStart = false;

    }

    public override void Update()
    {
        base.Update();// �θ��� Update �Լ� ���� 

        //player.DestrtoyObject(); 

        if (player.IsGroundDetected())
        {
            player.stateMachine.ChangeState(player.idleState);
        }
        

        player.rb.velocity = Vector2.down * Time.deltaTime * 3f;            

        if (!player.isBonusTime)
            return;

    }
}

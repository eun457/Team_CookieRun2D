using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDoubleJumpState : PlayerState
{
    [SerializeField] string effectAudioClipPath = "Basic_DJump";
    [SerializeField] string effectAudioClipPath1 = "PanCake_DoubleJump";
    [SerializeField] string effectAudioClipPath2 = "Moonlight_DJump";

    public PlayerDoubleJumpState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();

        //������ �ε�
        HE_DataManager.instance.LoadData();
        MycookiesData data = HE_DataManager.instance.GetMycookiesDatas().Find(cookie => cookie.id == UserDataManager.Instance.GetSelectCookieID());

        //Effect���
        if (data.id == 100)
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
        }
        else if (data.id == 101)
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath1);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
        }
        else if (data.id == 102)
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath2);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
        }

        rb.velocity = Vector2.zero;

            rb.AddForce(new Vector2(rb.velocity.x, player.GetJumpPower()), ForceMode2D.Impulse);
    } 

    public override void Update()
    {
        base.Update();

        if(rb.velocity.y < 0)
        {
            stateMachine.ChangeState(player.airState);
        }
        if (Input.GetKey(KeyCode.S))
        {
            stateMachine.ChangeState(player.slideState);
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

        if (player.isDashing || (player.isDashing && player.isGigantic))
        {
            player.GroundScrollSpeed = player.OriginalGroundScrollSpeed * 3;
        }
        if (player.isGigantic || (player.isGigantic && player.isDashing))
        {
            player.transform.localScale = player.OriginalSize * player.GetGiganticMaxSize();
            //player.transform.localScale = player.OriginalSize * 3;
        }
    }

    public override void Exit()
    {
        base.Exit();
        

    }

}

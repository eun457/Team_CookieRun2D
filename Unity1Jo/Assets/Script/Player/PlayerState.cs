using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected Rigidbody2D rb;

    public BoxCollider2D collider; // code by. 대석
    
    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;


    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) //생성자
    {
        //인자로 받은 것을 변수에 넣어줌
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }


    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        collider = player.collider; // code by. 대석
        triggerCalled = false;
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;//Dash timer 등의 기능

        player.anim.SetFloat("yVelocity", rb.velocity.y); //JumpFall애니메이션의 블렌딩값 적용
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBoolName, false);
    }

    public virtual void AnimationFinishTrigger()
    {
        triggerCalled = true;
    }
}

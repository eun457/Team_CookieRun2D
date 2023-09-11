using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;

    protected UI_InGame ingameuiManager; // code.by. �뼮

    protected Rigidbody2D rb;

    public BoxCollider2D collider; // code by. �뼮

    
    private string animBoolName;

    protected float stateTimer;
    protected bool triggerCalled;
    protected bool isjumping; // code by. �뼮


    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) //������
    {
        //���ڷ� ���� ���� ������ �־���
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBoolName = _animBoolName;
    }


    public virtual void Enter()
    {
        player.anim.SetBool(animBoolName, true);
        rb = player.rb;
        collider = player.collider1; // code by. �뼮
        triggerCalled = false;
        ingameuiManager = GameObject.Find("InGameUI").GetComponent<UI_InGame>();// code by. �뼮
       
       
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;//Dash timer ���� ���

        player.anim.SetFloat("yVelocity", rb.velocity.y); //JumpFall�ִϸ��̼��� ������ ����


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

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerSlideState slideState { get; private set; }
    public PlayerDashState dashState { get; private set; }
    public PlayerGiganticState giganticState { get; private set;}
    public PlayerHighState highState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDownState downState { get; private set; }
    public PlayerHitState hitState { get; private set; }

    public PlayerDeathState deathState { get; private set; }

    #endregion

    [Header("player")]
    [SerializeField] float hp;
    [SerializeField] float originSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float originSize;
    [SerializeField] float giganticSize;

    [Header("Collision Info")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask whatIsGround;

    #region Components 
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public PlayerFX fx { get; private set; } //code by. ����_Damage()�� ���

    #endregion

    public bool isBusy { get; private set; }



    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        //idleState = new PlayerIdleState(this, stateMachine, "Idle"); //this : �ڱ�����(Player)
        //jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        //airState = new PlayerAirState(this, stateMachine, "Jump");
        //dashState = new PlayerDashState(this, stateMachine, "Dash");
        //hitState = new PlayerHitState(this, stateMachine, "Hit");
        //giganticState = new PlayerGiganticState(this, stateMachine, "Gigantic");
        highState = new PlayerHighState(this, stateMachine, "High");
        downState = new PlayerDownState(this, stateMachine, "High");
        deathState = new PlayerDeathState(this, stateMachine, "Death");
    }


    private void Start()
    {
        anim = GetComponentInChildren<Animator>(); //�ڽ��� <Animator>()������
        rb = GetComponent<Rigidbody2D>();
       // stateMachine.Initialize(idleState); //ó������ idle���·�    
    }

    //code by. ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            Damage();
        }
    }

    // code by. ����
    public void Damage()
    {
        fx.StartCoroutine("FlashFX");
    }
    
}

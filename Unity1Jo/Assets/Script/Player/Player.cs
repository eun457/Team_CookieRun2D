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

    public PlayerDoubleJumpState doubleJumpState { get; private set; } // code by 대석

    public PlayerDeathState deathState { get; private set; }

    public PlayerBonusDownState bonusDownState { get; private set; }
    public PlayerBonusUpState bonusUpState { get; private set; }

    #endregion

    [Header("player")]
    [SerializeField] float hp;
    [SerializeField] float originSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float originSize;
    [SerializeField] float giganticSize;
    public float jumpPower; // code by. 대석

    [Header("Bonus Map Info")]      // code by. 동호
    public float topTime;           // 최대로 올라갈 떄의 시간  
    public GameObject topPos;       // 쿠키가 보너스 타임으로 갈 때 최대로 올라 갈 수 있는 위치
    public float downTime;          // 중앙 위치로 갈 때의 시간 
    public GameObject middlePos;    // 쿠키가 최대로 올라간 후 중앙 위치로 가는 위치 


    [Header("Collision Info")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask whatIsGround;

    #region Components 
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public PlayerFX fx { get; private set; } //code by. 하은_Damage()에 사용

    public BoxCollider2D collider { get; private set; } // code by. 대석

    #endregion

    public bool isBusy { get; private set; }



    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle"); //this : 자기참조(Player)
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        doubleJumpState = new PlayerDoubleJumpState(this, stateMachine, "DoubleJump"); // code by. 대석
        slideState = new PlayerSlideState(this, stateMachine, "Slide");
        airState = new PlayerAirState(this, stateMachine, "DoubleJump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        hitState = new PlayerHitState(this, stateMachine, "Hit");
        giganticState = new PlayerGiganticState(this, stateMachine, "Gigantic");
        highState = new PlayerHighState(this, stateMachine, "High");
        downState = new PlayerDownState(this, stateMachine, "Down");
        deathState = new PlayerDeathState(this, stateMachine, "Death");
        bonusDownState = new PlayerBonusDownState(this, stateMachine, "BonusDown");
        bonusUpState = new PlayerBonusUpState(this, stateMachine, "BonusUp");
    }


    private void Start()
    {
        anim = GetComponentInChildren<Animator>(); //자식의 <Animator>()가져옴
        rb = GetComponent<Rigidbody2D>();
        fx = GetComponent<PlayerFX>();
        collider = GetComponent<BoxCollider2D>(); // code by. 대석

        stateMachine.Initialize(idleState); //처음에는 idle상태로      
    }

    public void Update()
    {
        stateMachine.currentState.Update();

    }

    //code by. 하은
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("적!!!!!!!!!!!!!!!!!!!"); //code by. 준 적 충돌 확인용
            Damage();
        }
    }

    // code by. 하은
    public void Damage()
    {
       // fx.StartCoroutine("FlashFX"); //오류나서 일단 주석처리했습니다 .준
    }

    // code by. 대석
    public bool IsGroundDetected()
        => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    // code by. 대석
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }
}


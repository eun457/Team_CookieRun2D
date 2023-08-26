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
    public PlayerHighState highState { get; private set; } // code by.��ȣ
    public PlayerAirState airState { get; private set; }
    public PlayerDownState downState { get; private set; } // code by.��ȣ
    public PlayerHitState hitState { get; private set; }

    public PlayerDoubleJumpState doubleJumpState { get; private set; } // code by �뼮

    public PlayerDeathState deathState { get; private set; } // code by.��ȣ

    public PlayerBonusDownState bonusDownState { get; private set; }// code by.��ȣ
    public PlayerBonusUpState bonusUpState { get; private set; } // code by.��ȣ
    
    public PlayerFallingState fallingState { get; private set; } // code by.��ȣ


    #endregion

    [Header("player")]
    [SerializeField] float hp;
    [SerializeField] float originSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float originSize;
    [SerializeField] float giganticSize;
    [SerializeField] public float jumpPower; // code by. �뼮

    [Header("Bonus Map Info")]      // code by. ��ȣ
    public float topTime;           // �ִ�� �ö� ���� �ð�  
    public GameObject topPos;       // ��Ű�� ���ʽ� Ÿ������ �� �� �ִ�� �ö� �� �� �ִ� ��ġ
    public float downTime;          // �߾� ��ġ�� �� ���� �ð� 
    public GameObject middlePos;    // ��Ű�� �ִ�� �ö� �� �߾� ��ġ�� ���� ��ġ 
    public float bonusJumpPower = 1; // ��Ű�� ������ư Ŭ�� �� �ö� �ӵ� �Ŀ� ����    
    [SerializeField] GameObject shinyEffect;  


    [Header("Collision Info")]
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask whatIsGround;

    #region Components 
    public Animator anim { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public PlayerFX fx { get; private set; } //code by. ����_Damage()�� ���

    public BoxCollider2D collider { get; private set; } // code by. �뼮

    #endregion

    public bool isBusy { get; private set; }

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, stateMachine, "Idle"); //this : �ڱ�����(Player)
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        doubleJumpState = new PlayerDoubleJumpState(this, stateMachine, "DoubleJump"); // code by. �뼮
        slideState = new PlayerSlideState(this, stateMachine, "Slide");
        airState = new PlayerAirState(this, stateMachine, "DoubleJump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");
        hitState = new PlayerHitState(this, stateMachine, "Hit");
        giganticState = new PlayerGiganticState(this, stateMachine, "Gigantic");
        highState = new PlayerHighState(this, stateMachine, "High"); // code by.��ȣ
        downState = new PlayerDownState(this, stateMachine, "Down"); // code by.��ȣ
        deathState = new PlayerDeathState(this, stateMachine, "Death");
        bonusDownState = new PlayerBonusDownState(this, stateMachine, "BonusDown"); // code by.��ȣ
        bonusUpState = new PlayerBonusUpState(this, stateMachine, "BonusUp"); // code by.��ȣ
        fallingState = new PlayerFallingState(this, stateMachine, "Falling"); // code by.��ȣ 
    }


    private void Start()
    {
        anim = GetComponentInChildren<Animator>(); //�ڽ��� <Animator>()������
        rb = GetComponent<Rigidbody2D>();
        fx = GetComponent<PlayerFX>();
        collider = GetComponent<BoxCollider2D>(); // code by. �뼮
        SetActiveShinyEffect(false);  // code by.��ȣ      


        stateMachine.Initialize(idleState); //ó������ idle���·�      
    }

    public void Update()
    {
        stateMachine.currentState.Update();

    }

    public IEnumerator BusyFor(float _second)
    {
        isBusy = true;
        yield return new WaitForSeconds(_second);
        isBusy = false;
    }

    //code by. ����
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("��!!!!!!!!!!!!!!!!!!!"); //code by. �� �� �浹 Ȯ�ο�
            Damage();
        }
    }

    // code by. ����
    public void Damage()
    {
       // fx.StartCoroutine("FlashFX"); //�������� �ϴ� �ּ�ó���߽��ϴ� .��
    }

    // code by. �뼮
    public bool IsGroundDetected()
        => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    // code by. �뼮
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }
    // code by. ��ȣ
    public void SetVelocity(float _xVelocity, float _yVelocity)
    {
        rb.velocity = new Vector2(_xVelocity, _yVelocity);  
    }  
    public float GetJumpPower()
    {
        return jumpPower;
    }
    public void SetActiveShinyEffect(bool flag)
    {
        shinyEffect.SetActive(flag);      
    }
    public GameObject GetShinyEffect()
    {
        return shinyEffect;
    }
}


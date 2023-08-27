using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITest : UI_Base
{
    [SerializeField] Button Jump;
    [SerializeField] Button Slide;
    [SerializeField] GameObject PausePanel;
    [SerializeField] Button Pause;
    [SerializeField] Button KeepGame;
    bool _buttonPush; // button push flag
   
    Player player;

    public bool bonusTimeFinish = false; // ���ʽ� �ð� ������ �� üũ (�̰Ŵ� UIManager���� ���ʽ�Ÿ���� ������ �� �˾ƾ� �� �÷��� ���� )
    private void Start()
    {
        //BonusJump.gameObject.AddUIEvent(ButtonClicked, type : Define.UIEvent.PointerDown);  
        Jump.gameObject.AddUIEvent(JumpButton, type: Define.UIEvent.PointerDown); // ��ư �ٿ� ���� �� �̺�Ʈ ��� (Ÿ���� �⺻�� : Define.UIEvent.Click)
        Jump.gameObject.AddUIEvent(JumpButtonUp, type: Define.UIEvent.PointerUp); // ��ư �� ���� �� �̺�Ʈ ��� (Ÿ���� �⺻�� : Define.UIEvent.Click)
        Jump.gameObject.AddUIEvent(DoubleJump, type: Define.UIEvent.PointerDown);
        Jump.gameObject.AddUIEvent(DoubleJumpUP, type: Define.UIEvent.PointerUp);
        Pause.gameObject.AddUIEvent(PauseGame, type: Define.UIEvent.PointerDown);
        KeepGame.gameObject.AddUIEvent(PauseCancle, type: Define.UIEvent.PointerDown);

        Slide.gameObject.AddUIEvent(SlideButton, type: Define.UIEvent.PointerDown);
        Slide.gameObject.AddUIEvent(SlideButtonUp, type: Define.UIEvent.PointerUp);

        GameObject playerObj = PlayerManager.Instance.GetPlayer(); // PlayManager��� �̱��� Ŭ�������� �÷��̾� ���� ������Ʈ ����.
        if (playerObj == null) // �÷��̾� ������Ʈ�� ������ ���� 
            return;
        player = playerObj.GetComponent<Player>(); // �÷��̾� ������Ʈ ������ 
    }

    void PauseGame(PointerEventData data)
    {
        _buttonPush = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    void PauseCancle(PointerEventData data)
    {
        _buttonPush = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void JumpButton(PointerEventData data)
    {
        _buttonPush = true;
       
        
        if(player == null) return;
        if (player.IsGroundDetected())
        {
            player.stateMachine.ChangeState(player.jumpState);
        }
    }

    void JumpButtonUp(PointerEventData data)
    {
        _buttonPush = false;
       
    }

    void DoubleJump(PointerEventData data)
    {
        _buttonPush = true;

        if(player == null) return;
        if (!player.IsGroundDetected())
            player.stateMachine.ChangeState(player.doubleJumpState);
        
    }

    void DoubleJumpUP(PointerEventData data)
    {
        _buttonPush = false;
    }

    void SlideButton(PointerEventData data)
    {
        _buttonPush = true;
        if(player == null) return;
        if(player.IsGroundDetected())
            player.stateMachine.ChangeState(player.slideState);
    }

    void SlideButtonUp(PointerEventData data)
    {
        _buttonPush = false;
        player.stateMachine.ChangeState(player.idleState);
    }



    // code by ��ȣ
    void OnButtonDown(PointerEventData data) // ���ʽ� Ÿ�ӿ����� �÷��̾� ���� ��ư Ŭ���� 
    {
        Debug.Log("OnButtonDown");
        _buttonPush = true; // ��ư Ǫ�� �÷��� Ȱ��ȭ
        if (player == null)  // �÷��̾� ������Ʈ ������ ���� 
            return;

        if (bonusTimeFinish == true) // ���ʽ� Ÿ���� �������� ���� 
            return;
        player.stateMachine.ChangeState(player.bonusUpState); // ���ʽ� ���¿����� ���� ���°� ��.
        StartCoroutine(JumpBonusTime());  // ���� �ڷ�ƾ ���� 
    }
    // code by ��ȣ
    void OnButtonUp(PointerEventData data)
    {
        _buttonPush = false; // ��ư Ǫ�� �÷��� ��Ȱ��ȭ
        if (player == null) // �÷��̾� ������Ʈ ������ ���� 
            return;

        if (bonusTimeFinish == true) // ���ʽ� Ÿ���� �������� ���� 
            return;
        player.stateMachine.ChangeState(player.bonusDownState); // ���ʽ� ���¿����� �ٿ� ���°� ��.  


    }
    // code by ��ȣ
    IEnumerator JumpBonusTime()
    {
        while (_buttonPush) // ��ư�� ���� ���¶�� 
        {
            PlayerBonusJump();
            yield return new WaitForSeconds(0.1f); // �ش� �ð� ���� ����.

        }
    }
    // code by ��ȣ
    void PlayerBonusJump() // ���� ���� 
    {
        player.SetVelocity(0, player.bonusJumpPower);  // �÷��̾��� ������ �ٵ��� �ӵ��� ��������.
    }
}
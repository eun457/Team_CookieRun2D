using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CanvasTest : UI_Base
{
    [SerializeField] Button BonusJump;
    bool _buttonPush; // button push flag
    Player player;

    public bool bonusTimeFinish = false; // ���ʽ� �ð� ������ �� üũ (�̰Ŵ� UIManager���� ���ʽ�Ÿ���� ������ �� �˾ƾ� �� �÷��� ���� )
    private void Start()
    {
        //BonusJump.gameObject.AddUIEvent(ButtonClicked, type : Define.UIEvent.PointerDown);  
        BonusJump.gameObject.AddUIEvent(OnButtonDown, type : Define.UIEvent.PointerDown); // ��ư �ٿ� ���� �� �̺�Ʈ ��� (Ÿ���� �⺻�� : Define.UIEvent.Click)
        BonusJump.gameObject.AddUIEvent(OnButtonUp, type: Define.UIEvent.PointerUp); // ��ư �� ���� �� �̺�Ʈ ��� (Ÿ���� �⺻�� : Define.UIEvent.Click)
        //GameObject playerObj = PlayerManager.Instance.GetPlayer(); // PlayManager��� �̱��� Ŭ�������� �÷��̾� ���� ������Ʈ ����.
        //if (playerObj == null) // �÷��̾� ������Ʈ�� ������ ���� 
        //    return;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (playerObj == null) // �÷��̾� ������Ʈ�� ������ ���� 
            return;
        player = playerObj.GetComponent<Player>(); // �÷��̾� ������Ʈ ������ 
    }

    // code by ��ȣ
    void OnButtonDown(PointerEventData data) // ���ʽ� Ÿ�ӿ����� �÷��̾� ���� ��ư Ŭ���� 
    {
        Debug.Log("OnButtonDown");    
        _buttonPush = true; // ��ư Ǫ�� �÷��� Ȱ��ȭ
        if (player == null )  // �÷��̾� ������Ʈ ������ ���� 
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

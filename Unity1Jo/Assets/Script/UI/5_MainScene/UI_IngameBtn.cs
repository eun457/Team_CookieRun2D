using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_IngameBtn : UI_EventBase
{
    [SerializeField] Button Jump;
    [SerializeField] Button Slide;
    [SerializeField] GameObject PausePanel;
    [SerializeField] Button Pause;
    [SerializeField] Button KeepGame;
    [SerializeField] Button ReStart;
    [SerializeField] Button GiveUp;
    [SerializeField] Button BonusJumpBtn;
    [SerializeField] Button BonusSlideBtn;
    bool _buttonPush; // button push flag
    bool isjumping = false; // ���� ���� �÷���
    Player player;
    UI_InGame gameUIManager;

    public bool bonusTimeFinish = false; // ���ʽ� �ð� ������ �� üũ (�̰Ŵ� UIManager���� ���ʽ�Ÿ���� ������ �� �˾ƾ� �� �÷��� ���� )

    [SerializeField] string effectAudioClipPath = "E_ClickBtn";
    private void Start()
    {
        //BonusJump.gameObject.AddUIEvent(ButtonClicked, type : Define.UIEvent.PointerDown);  
        Jump.gameObject.AddUIEvent(JumpButton, type: Define.UIEvent.PointerDown); // ��ư �ٿ� ���� �� �̺�Ʈ ��� (Ÿ���� �⺻�� : Define.UIEvent.Click)
        Jump.gameObject.AddUIEvent(JumpButtonUp, type: Define.UIEvent.PointerUp); // ��ư �ٿ� ���� �� �̺�Ʈ ��� (Ÿ���� �⺻�� : Define.UIEvent.Click)
        Jump.gameObject.AddUIEvent(DoubleJump, type: Define.UIEvent.PointerDown);
        Jump.gameObject.AddUIEvent(DoubleJumpUP, type: Define.UIEvent.PointerUp);
        Pause.gameObject.AddUIEvent(PauseGame);
        KeepGame.gameObject.AddUIEvent(PauseCancle);
        ReStart.gameObject.AddUIEvent(ReStartDown);
        GiveUp.gameObject.AddUIEvent(GiveUP);

        Slide.gameObject.AddUIEvent(SlideButton, type: Define.UIEvent.PointerDown);
        Slide.gameObject.AddUIEvent(SlideButtonUp, type: Define.UIEvent.PointerUp);

        BonusJumpBtn.gameObject.AddUIEvent(OnButtonDown, type: Define.UIEvent.PointerDown); // ��ư �ٿ� ���� �� �̺�Ʈ ��� (Ÿ���� �⺻�� : Define.UIEvent.Click)
        BonusJumpBtn.gameObject.AddUIEvent(OnButtonUp, type: Define.UIEvent.PointerUp); // ��ư �� ���� �� �̺�Ʈ ��� (Ÿ���� �⺻�� : Define.UIEvent.Click)

        BonusSlideBtn.gameObject.AddUIEvent(OnButtonDown, type: Define.UIEvent.PointerDown); // ��ư �ٿ� ���� �� �̺�Ʈ ��� (Ÿ���� �⺻�� : Define.UIEvent.Click)
        BonusSlideBtn.gameObject.AddUIEvent(OnButtonUp, type: Define.UIEvent.PointerUp); // ��ư �� ���� �� �̺�Ʈ ��� (Ÿ���� �⺻�� : Define.UIEvent.Click)

        BonusJumpBtn.gameObject.SetActive(false);
        BonusSlideBtn.gameObject.SetActive(false);

        //GameObject playerObj = PlayerManager.Instance.GetPlayer(); // PlayManager��� �̱��� Ŭ�������� �÷��̾� ���� ������Ʈ ����.
        //if (playerObj == null) // �÷��̾� ������Ʈ�� ������ ���� 
        //    return;
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player").gameObject;
        if (playerObj == null) // �÷��̾� ������Ʈ�� ������ ���� 
            return;
        player = playerObj.GetComponent<Player>(); // �÷��̾� ������Ʈ ������ 
        gameUIManager = GetComponent<UI_InGame>();
    }

    void GiveUP(PointerEventData data)
    {
        Time.timeScale = 1;

        //Effect���
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

        SceneManager.LoadScene("ResultScene");
        SoundManager.Instance.Clear();
        SpawnManager.Instance.gameObject.GetComponent<SpawnManager>().enabled = false;

    }

    void ReStartDown(PointerEventData data)
    {
        GameManager.Instance.totalCoin -= GameManager.Instance.currentCoin;
        GameManager.Instance.currentCoin = 0;
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1;
        player.mapcount = 0;
        player.isMapChange = true;
        SpawnManager.Instance.ChangeJellyPrefab(SpawnManager.Instance.whatjelly[0], SpawnManager.Instance.image0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[0], SpawnManager.Instance.Short0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[1], SpawnManager.Instance.Long0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[2], SpawnManager.Instance.Slide0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[3], SpawnManager.Instance.LongSlide0);

        //Effect���
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

        // BGM�� �ٽ� ���
        SoundManager.Instance.PlayBGM();

        //GameObject Mbonus = GameObject.Find("BonusMap").gameObject;
        //Mbonus.SetActive(false);     
    }
    public void SetButtonPush(bool flag)
    {
        _buttonPush = flag;
    }
    void PauseGame(PointerEventData data)
    {
        _buttonPush = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0;

        SoundManager.Instance.PauseBGM();

        //Effect���
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);  
    }

    void PauseCancle(PointerEventData data)
    {
        _buttonPush = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1;

        //Effect���
        AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
        if (effectAudioClip != null)
            SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);

        SoundManager.Instance.ResumeBGM();
    }

    void JumpButton(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)  
            return;

        if(player.isBonusStart == true)
        {
            if (player.gValue <= 0)
                return;
            BonusTimeButtonDown();
        }
        else
        {
            _buttonPush = true;

            if (player == null) return;

            if (player.IsGroundDetected())
            {
                isjumping = true;
                player.stateMachine.ChangeState(player.jumpState);
            }
        }

    }

    void JumpButtonUp(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)
            return;

        if (player.isBonusStart == true)
        {
            if (player.gValue <= 0)
                return;
            BonusTImeButtonUp();
        }
        else
        {
            _buttonPush = false;

        }

    }

    void DoubleJump(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)
            return;

        if (player.isBonusStart == false)
        {
            _buttonPush = true;

            if (player == null) return;
            if (!player.IsGroundDetected() && isjumping)
            {
                isjumping = false;
                player.stateMachine.ChangeState(player.doubleJumpState);  
            }
        }    
    }

    void DoubleJumpUP(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)
            return;

        if (player.isBonusStart == false)
        {
            _buttonPush = false;
        }
    }

    void SlideButton(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)
            return;

        if (player.isBonusStart == true)
        {
            if (player.gValue <= 0)
                return;

            BonusTimeButtonDown();
        }
        else // falling state�� ������ 
        {
            if (player == null) return;

            if (player.IsGroundDetected())
            {
                player.stateMachine.ChangeState(player.slideState);  
            }

            _buttonPush = true;  

            Debug.Log("������!!!!!!!!!!!");  

        }

    }

    void SlideButtonUp(PointerEventData data)
    {
        if (player.stateMachine.currentState == player.fallingState
            || player.stateMachine.currentState == player.highState
            || player.stateMachine.currentState == player.downState
            || player.stateMachine.currentState == player.deathState)  
            return;

        if (player.isBonusStart == true)
        {
            if (player.gValue <= 0)  
                return;  
            BonusTImeButtonUp();
        }
        else
        {
            _buttonPush = false;

            player.anim.SetBool("Idle", true);
            player.stateMachine.ChangeState(player.idleState);
        }

    }



    // code by ��ȣ
    void BonusTimeButtonDown()
    {
        if (player == null)  // �÷��̾� ������Ʈ ������ ���� 
            return;

        if (player.isBonusStart == false && player.isBonusTime == false) // ���ʽ� Ÿ���� �������� ����     
            return;    

        _buttonPush = true; // ��ư Ǫ�� �÷��� Ȱ��ȭ

        player.stateMachine.ChangeState(player.bonusUpState); // ���ʽ� ���¿����� ���� ���°� ��.
        StartCoroutine(JumpBonusTime());  // ���� �ڷ�ƾ ���� 
    }
    void BonusTImeButtonUp()
    {
        _buttonPush = false; // ��ư Ǫ�� �÷��� ��Ȱ��ȭ
        if (player == null) // �÷��̾� ������Ʈ ������ ���� 
            return;

        if (player.isBonusStart == false) // ���ʽ� Ÿ���� �������� ���� 
            return;

        player.stateMachine.ChangeState(player.bonusDownState); // ���ʽ� ���¿����� �ٿ� ���°� ��. 
    }
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
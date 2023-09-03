using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : MonoBehaviour
{
    [SerializeField] Text scoreTxt;
    [SerializeField] Text coinTxt;
    [SerializeField] Text dialogueTxt;

    float targetScore;
    float currentScore;
    float targetCoin;
    float currentCoin;
    float timer = 0.0f;
    [SerializeField] float duration = 3.0f;

    void Start()
    {
        //������ �ε�
        HE_DataManager.instance.LoadData();

        currentScore = 0;
        targetScore = GameManager.Instance.currentJellyPoint;
        currentCoin = 0;
        targetCoin = GameManager.Instance.currentCoin;
    }
    void Update()
    {
        timer += Time.deltaTime;

        // ���ھ�� ������ ��ǥ���� ���������� ������Ű��
        if (timer < duration)
        {
            float progress = timer / duration;
            currentScore = Mathf.Lerp(0, targetScore, progress);
            currentCoin = Mathf.Lerp(0, targetCoin, progress);
        }
        else
        {
            currentScore = targetScore;
            currentCoin = targetCoin;
        }

        // �ؽ�Ʈ ������Ʈ
        scoreTxt.text = string.Format("{0:#,0}", currentScore);
        coinTxt.text = string.Format("{0:#,0}", currentCoin); //���ڸ������� ,���

        MycookiesData data = HE_DataManager.instance.GetMycookiesDatas().Find(cookie => cookie.id == UserDataManager.Instance.GetSelectCookieID());
        if (data != null)
        {
            int id = data.id;
            switch (id)
            {
                case 100:
                    dialogueTxt.text = "�޸��� �ϸ� ����!";
                    break;
                case 101:
                    dialogueTxt.text = "�����~ ���� ����~";
                    break;
                case 102:
                    dialogueTxt.text = "��~ ��~ ��踦 ���ڱ�!";
                    break;
                case 103:
                    dialogueTxt.text = "�����.. ���Ŵ�, ����...";
                    break;
                case 104:
                    dialogueTxt.text = "���� �ٴ� ����̿���";
                    break;
            }
        }
    }
}

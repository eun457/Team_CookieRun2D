using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIMyCookies : MonoBehaviour //code by. ����
{
    public UIScrollView uiScrollView;
    public Text coinTxt;

    public void Initialize() //��ȭ, �Ǹ޴�, ��ũ�Ѻ� ��� �ʱ�ȭ
    {
        //��ũ�Ѻ� �ʱ�ȭ
        uiScrollView.Initialize();
    }

    public void Update()
    {
        coinTxt.text = string.Format("{0:n0}", GameManager.Instance.totalCoin);
    }

}

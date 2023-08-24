using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYCOOKIES_Main : MonoBehaviour
{
    public UIMyCookies uiMyCookies;

    void Start()
    {
        //������ �ε�
        HE_DataManager.instance.LoadData();

        //��ưŬ�� ���� ����
        EventManager.instance.onSelectBtnClick = () => {
            Debug.Log("�� ĳ���Ͱ� ���õǾ����ϴ�");
        };

        EventManager.instance.onBuyBtnClick = (id) => {
            var data = HE_DataManager.instance.GetData(id);
            Debug.LogFormat("{0},{1},{2}", data.id, data.name, data.price);
        };

        //UIMyCookies �ʱ�ȭ
        uiMyCookies.Initialize();
    }
}

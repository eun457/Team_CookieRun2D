using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class HE_DataManager //Ȥ�� DataManager�� �� ����� ������� �浹������ HE �޾Ƶ�. ���߿� DataManager�� �̸� ��������
{
    public static readonly HE_DataManager instance = new HE_DataManager();

    //�÷��� �ʱ�ȭ
    private Dictionary<int, MycookiesData> dicMycookiesData;// = new Dictionary<int, MycookiesData>(); -> ���ӽ����̽��� using System.Linq���༭ �ʿ������

    private HE_DataManager() { }

    public MycookiesData GetData(int id)
    {
        return dicMycookiesData[id];
    }
    public void LoadData()
    {
        //TextAsset�� �ε�
        TextAsset asset = Resources.Load<TextAsset>("Data/Mycookies_data"); //Resources����-Data����-Mycookies_data������ Load�ض�
        //asset�� ���ڿ� ���
        var json = asset.text;
        Debug.Log(asset.text);

        //������ȭ
        MycookiesData[] arrMycookiesDatas = JsonConvert.DeserializeObject<MycookiesData[]>(json);

        dicMycookiesData = arrMycookiesDatas.ToDictionary(x => x.id); //���ο� ���� ��ü�� ���� ��ȯ

        Debug.LogFormat("Mycookies data loaded! :{0}", dicMycookiesData.Count);
    }

    public List<MycookiesData> GetMycookiesDatas()
    {
        return dicMycookiesData.Values.ToList();
    }
}

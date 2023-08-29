using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;

public class HE_DataManager //Ȥ�� DataManager�� �� ����� ������� �浹������ HE �޾Ƶ�. ���߿� DataManager�� �̸� �������� //code by. ����
{
    public static readonly HE_DataManager instance = new HE_DataManager();

    //arrMycookiesDatas�� key(id)-value�� �Ǿ��־ Dictionary �÷��� ���
    private Dictionary<int, MycookiesData> dicMycookiesData;// = new Dictionary<int, MycookiesData>(); -> using System.Linq�� ����ؼ� �ʱ�ȭ �ʿ����

    private HE_DataManager() { }

    public MycookiesData GetData(int id)
    {
        return dicMycookiesData[id];
    }
    public void LoadData()
    {
        //TextAsset�� �ε�(Resources����-Data����-Mycookies_data������ Load)
        TextAsset asset = Resources.Load<TextAsset>("Data/MyCookies_data");
        //asset�� ���ڿ� ���
        var json = asset.text;

        //������ȭ
        MycookiesData[] arrMycookiesDatas = JsonConvert.DeserializeObject<MycookiesData[]>(json);

        //key�� id�� �ؼ� ���ο� ���� ��ü�� �����Ǿ� ��ȯ��(for������ dicMycookiesData(data.id, data)���� �Ͱ� ���� ���)
        dicMycookiesData = arrMycookiesDatas.ToDictionary(x => x.id); 
    }

    //dicMycookiesData�� Values�� List�� ��ȯ
    public List<MycookiesData> GetMycookiesDatas()
    {
        return dicMycookiesData.Values.ToList();
    }

    public Dictionary<int, MycookiesData> GetMyCookiesData()
    {
        return dicMycookiesData;
    }
}

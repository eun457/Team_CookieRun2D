using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UserDataManager : SingletonBehaviour<UserDataManager>
{
    [SerializeField] private int selectCookieID =100;  // ������ ��Ű�� ID �� 
    [SerializeField] private int selectPetID = 100;

    private Dictionary<int, int> HasCookieDic = new Dictionary<int, int>();
    private Dictionary<int, int> HasPetDic = new Dictionary<int, int>();
    private void Awake()
    {
        base.Awake();
        CookieDicInit();
    }

    private void Start()
    {
  
    }
    public void CookieDicInit() // ��Ű ������ �ε� �� cookie dictionary init 
    {
        CookiesDataManager.instance.LoadData();
        HasCookieDic.Clear();
        foreach (var data in CookiesDataManager.instance.GetMycookiesDatas())
        {
            if(data.id == 100)
            {
                HasCookieDic.Add(data.id, 1);
            }
            else
            {
                HasCookieDic.Add(data.id, 0);

            }
        }
    }
    public void PetDicInit() // �� ������ �ε� �� pet dictionary init 
    {
        HasPetDic.Clear();
        HasPetDic.Add(100, 1);
    }

    /* Cookie Dic */
    public void SetHasCookie(int key, bool hasCookie) // �ش� ��Ű�� �ִ��� üũ 
    {
        if (HasCookieDic.ContainsKey(key))
        {
            HasCookieDic[key] = hasCookie ? 1 : 0;
        }
        return;
    }

    public int GetHasCookie(int key)
    {
        if (HasCookieDic.ContainsKey(key))
        {
            return HasCookieDic[key];
        }
        return 0; //�⺻ ���� 0
    }

    /* Pet Dic */
    public void SetHasPet(int key, bool hasPet)
    {
        if (HasPetDic.ContainsKey(key))
        {
            HasPetDic[key] = hasPet ? 1 : 0;
        }
        return;
    }
    public int GetHasPet(int key)
    {
        if (HasPetDic.ContainsKey(key))
        {
            return HasPetDic[key];
        }
        return 0;
    }

    /* Setter & Getter cookie ID*/
    public void SetSelectCookieID(int id)
    {
        selectCookieID = id;  
    }
    public int GetSelectCookieID()
    {
        return selectCookieID;
    }

    /* Setter & Getter Pet ID */
    public void SetSelectPetID(int id)
    {
        selectPetID = id;
    }
    public int GetSelectPetID()
    {
        return selectPetID;
    }
}

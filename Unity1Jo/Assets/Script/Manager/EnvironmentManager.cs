using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scene = UnityEngine.SceneManagement.Scene;

public class EnvironmentManager : SingletonBehaviour<EnvironmentManager>
{
    [SerializeField] GameObject InGame_EnvironmentObjs;
    [SerializeField] GameObject BonusTime_EnvironmentObjs;  

    // code by ��ȣ
    void Awake()
    {
        base.Awake(); // �θ��� awake ȣ�� 
    }
    private void Start()
    {
        SetActiveBonusTimeEnvironment(false);  
    }
    // code by ��ȣ
    public void SetActiveInGameEnvironment(bool flag)
    {
        InGame_EnvironmentObjs.SetActive(flag);
    }
    // code by ��ȣ
    public void SetActiveBonusTimeEnvironment(bool flag)      
    {
        BonusTime_EnvironmentObjs.SetActive(flag);  
    }

    // code by �뼮
    // ���� �Ѿ�� BonusMap false ���·� ��ȯ
    //public void BonusMapLoad(Scene scene, LoadSceneMode mode)
    //{
    //    if(BonusTime_EnvironmentObjs != null)
    //    {
    //        BonusTime_EnvironmentObjs.SetActive(false);
    //    }
    //}
}

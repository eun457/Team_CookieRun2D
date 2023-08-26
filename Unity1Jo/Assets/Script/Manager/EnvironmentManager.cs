using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}

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


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTestManager : MonoBehaviour
{
    public static SpawnTestManager Instance;

    public void Awake()
    {
        if (Instance == null) //�������� �ڽ��� üũ��, null����
        {
            Instance = this; //���� �ڱ� �ڽ��� ������.
        }
    }

    //public List<int> Listindex = new List<int>();
    //public List<int> ListJellyType = new List<int>();
    //public List<int> ListJellyYpos = new List<int>();
    //public List<int> ListJellyAmount = new List<int>();
    //public List<int> ListObstacleType = new List<int>();
    //public List<int> ListObstacle = new List<int>();
    //public List<int> ListGround = new List<int>();

}

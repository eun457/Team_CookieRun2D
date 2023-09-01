//������ �� ��ֹ� ���� �Ŵ���
//������ �� ��ֹ� ���� �Ŵ���
//������ �� ��ֹ� ���� �Ŵ���
//������ �� ��ֹ� ���� �Ŵ���

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Experimental.GlobalIllumination;
using Random = UnityEngine.Random;//�����Լ� ó��

public class Spawnanager : SingletonBehaviour<Spawnanager>
{

    void Awake()
    {
        base.Awake();
    }


    public Transform[] SpawnPos; //���� ������ //yPos
    public GameObject SpawnObject;
    public GameObject Spawn10Pos;

    public GameObject[] whatjelly; //���� Ÿ��
    public GameObject[] whatobstacle; //��ֹ� Ÿ��

    Player p;


    [SerializeField] int patternNum; //���� ��ȣ
    [SerializeField] float SpawnSpeed;
    float LastSpawnTime;

    int jellytype;
    int jellyYpos;
    int jellyAmount;
    int obstacleType;
    int obstacle;
    int mapindex;

    public string map1 = "Assets/Resources/data.json";
    public string map2 = "Assets/Resources/data.json"; // �� ������ �߰� ����
    public string map3 = "Assets/Resources/data.json"; // �� ������ �߰� ����
    public string map4 = "Assets/Resources/data.json"; // �� ������ �߰� ����
    public string CurrentMap;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        patternNum = 0; //indexnumber
        Spawn10Pos = Instantiate(SpawnObject, gameObject.transform.position, Quaternion.identity);
        Spawn10Pos.transform.parent = gameObject.transform;
        for(int i = 0; i < transform.GetChild(0).transform.childCount; i++)
        {
            SpawnPos[i] = transform.GetChild(0).transform.GetChild(i);
        }

    }


    void FixedUpdate()
    {
        //���߿� Ư�� ������ map���� �ϰ� ����
        if (p.mapcount == 0)
        {
            CurrentMap = map1; //���� ���� �� ���� �� == map1
            
        }
        else if (p.mapcount == 1 && p.isMapChange)
        {
            CurrentMap = map2;
            patternNum = 0;
            p.isMapChange = false;
        }
        else if (p.mapcount == 2 && p.isMapChange)
        {
            CurrentMap = map3;
            patternNum = 0;
            p.isMapChange = false;
        }
        else if (p.mapcount == 3 && p.isMapChange)
        {
            CurrentMap = map4;
            patternNum = 0;
            p.isMapChange = false;
        }
        string jsonFilePath = CurrentMap; //���ҽ� ���� �ȿ� �ִ� data�б�




        if (File.Exists(jsonFilePath)) //������ ������ ��
        {
            // JSON ���� �б�
            string jsonContent = File.ReadAllText(jsonFilePath);
            JsonData jsonData = JsonUtility.FromJson<JsonData>(jsonContent); //Json���� ���� ������ Class�� ����


            // ���

            if (Time.time > LastSpawnTime + SpawnSpeed / p.GroundScrollSpeed && patternNum < jsonData.index.Count)//���� ���� �ֱ�
            {
                LastSpawnTime = Time.time;

                StartCoroutine(spawn());
                jellytype = jsonData.JellyType[patternNum];     //������ �������� �ڷ�ƾ���� ���� ���� ��������
                jellyYpos = jsonData.JellyYpos[patternNum];     //������ �������� �ڷ�ƾ���� ���� ���� ��������
                obstacleType = jsonData.ObstacleType[patternNum];   //������ �������� �ڷ�ƾ���� ���� ���� ��������
                jellyAmount = jsonData.JellyAmount[patternNum];     //������ �������� �ڷ�ƾ���� ���� ���� ��������
                obstacle = jsonData.Obstacle[patternNum];           //������ �������� �ڷ�ƾ���� ���� ���� ��������
                patternNum++; //index���� ����.

            }

        }

        else //���� ���
        {
            Debug.LogError("JSON file not found at path: " + jsonFilePath);
        }

    }
    IEnumerator spawn() //���� �ڷ�ƾ
    {


        //���� ����
        for (int i = 0; i < jellyAmount; i++)
        {
            Instantiate(whatjelly[jellytype], SpawnPos[jellyYpos]);
            // yield return new WaitForSeconds(1 / p.GroundScrollSpeed); //�� ��ũ�� ���ǵ忡 ���缭 ����.
        }



        //���� ����. json���� ���� ���� 0�ϰ�� ���� x
        if (obstacleType >= 1)
        {
            for (int i = 0; i < obstacle; i++)
            {
                Instantiate(whatobstacle[obstacleType - 1], SpawnPos[0]);
                // yield return new WaitForSeconds(1 / p.GroundScrollSpeed); //�� ��ũ�� ���ǵ忡 ���缭 ����.

            }
        }
        yield return null;
    }



    [System.Serializable]
    public class JsonData //data���� ���� ���� �ֱ�
    {
        public List<int> index; // ��ȣ
        public List<int> JellyType; //���� Ÿ�� 
        public List<int> JellyYpos; //���� ���� ��ġ
        public List<int> JellyAmount; //���� ��
        public List<int> ObstacleType; //��ֹ� Ÿ��
        public List<int> Obstacle; //��ֹ�
    }

    public void ResetPatternNum()
    {
        patternNum = 0;
    }

}
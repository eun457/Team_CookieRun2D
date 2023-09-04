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
using UnityEngine.UIElements;
using JetBrains.Annotations;

public class Spawnanager : MonoBehaviour
{

    public static Spawnanager Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Transform[] SpawnPos; //���� ������ //yPos
    public GameObject SpawnObject;
    public GameObject Spawn10Pos;

    #region ChangeImage
    [SerializeField] public Sprite image0;
    [SerializeField] Sprite image1; // �ٲ�� ���� �̹���
    [SerializeField] Sprite image2;
    [SerializeField] Sprite image3;
    [SerializeField] Sprite image4;
    [SerializeField] public RuntimeAnimatorController Short0;
    [SerializeField] RuntimeAnimatorController Short1;
    [SerializeField] RuntimeAnimatorController Short2;
    [SerializeField] RuntimeAnimatorController Short3;
    [SerializeField] RuntimeAnimatorController Short4;
    [SerializeField] public RuntimeAnimatorController Long0;
    [SerializeField] RuntimeAnimatorController Long1;
    [SerializeField] RuntimeAnimatorController Long2;
    [SerializeField] RuntimeAnimatorController Long3;
    [SerializeField] RuntimeAnimatorController Long4;
    [SerializeField] public RuntimeAnimatorController Slide0;
    [SerializeField] RuntimeAnimatorController Slide1;
    [SerializeField] RuntimeAnimatorController Slide2;
    [SerializeField] RuntimeAnimatorController Slide3;
    [SerializeField] RuntimeAnimatorController Slide4;
    [SerializeField] public RuntimeAnimatorController LongSlide0;
    [SerializeField] RuntimeAnimatorController LongSlide1;
    [SerializeField] RuntimeAnimatorController LongSlide2;
    [SerializeField] RuntimeAnimatorController LongSlide3;
    [SerializeField] RuntimeAnimatorController LongSlide4;
    #endregion

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
    public string map5 = "Assets/Resources/data.json"; // �� ������ �߰� ����
    public string Bonusmap = "Assets/Resources/BonusMap.json"; // �� ������ �߰� ����
    public string CurrentMap;

    public string lastMap;
    public int lastPatternum;


    //public Material[] mat_map; // �� �̹����� ����� ���׸���                          

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        patternNum = 0; //indexnumber
        Spawn10Pos = Instantiate(SpawnObject, gameObject.transform.position - new Vector3(0, 0.75f, 0), Quaternion.identity);
        Spawn10Pos.transform.parent = gameObject.transform;
        p.isMapChange = false;
        for (int i = 0; i < transform.GetChild(0).transform.childCount; i++)
        {
            SpawnPos[i] = transform.GetChild(0).transform.GetChild(i);
        }
        CurrentMap = map1;

        selectedCamera = GameObject.Find("Main Camera").GetComponent<Camera>();

    }
    Camera selectedCamera;
    public bool isEnemyInsideCamera;
    public void CheckEnemy(GameObject _Enemy)//ī�޶� �� �ȿ� ���� �ִ��� ������
    {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            Vector3 viewPos = selectedCamera.WorldToViewportPoint(_Enemy.transform.position);
            if (viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1 && viewPos.z > 0)
            {

                isEnemyInsideCamera = true;
            }
            else
                isEnemyInsideCamera = false;
        }
        if (isEnemyInsideCamera)
            Debug.Log("���� ī�޶� �ȿ� ����");
            

    }
    void FixedUpdate()
    {
        CheckEnemy(GameObject.FindGameObjectWithTag("Enemy")); //ī�޶� �ȿ� ���� �ִ��� Ȯ���ϴ°�
        //if (p.isMapChange && !p.isBonusTime && p.mapcount == 0)
        //{
        //    CurrentMap = map1;
        //    patternNum = 0;
        //    p.isMapChange = false;
        //}
        //else if (p.isMapChange && !p.isBonusTime && p.mapcount == 1)
        //{
        //    CurrentMap = map2;
        //    patternNum = 0;
        //    p.isMapChange = false;
        //}
        //else if (p.isMapChange && !p.isBonusTime && p.mapcount == 2)
        //{
        //    CurrentMap = map3;
        //    patternNum = 0;
        //    p.isMapChange = false;
        //}
        //else if (p.isMapChange && !p.isBonusTime && p.mapcount == 3)
        //{
        //    CurrentMap = map4;
        //    patternNum = 0;
        //    p.isMapChange = false;
        //}


        if (p.isMapChange && !p.isBonusTime)
        {

            switch (p.mapcount)
            {
                case 0:
                    CurrentMap = map1;
                    // GetSpriteOrigin();
                    //ChangeJellyPrefab(whatjelly[0], image0);
                    ChangeEnemy(whatobstacle[0], Short0);
                    ChangeEnemy(whatobstacle[1], Long0);
                    ChangeEnemy(whatobstacle[2], Slide0);
                    ChangeEnemy(whatobstacle[3], LongSlide0);
                    MapController.Instance.ChangeMaterial(MapController.Instance.mat_ovenIn);

                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 1:
                    CurrentMap = map2;
                    ChangeJellyPrefab(whatjelly[0], image1);
                    ChangeEnemy(whatobstacle[0], Short1);
                    ChangeEnemy(whatobstacle[1], Long1);
                    ChangeEnemy(whatobstacle[2], Slide1);
                    ChangeEnemy(whatobstacle[3], LongSlide1);
                    MapController.Instance.ChangeMaterial(MapController.Instance.mat_map);

                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 2:
                    CurrentMap = map3;
                    ChangeJellyPrefab(whatjelly[0], image2);
                    ChangeEnemy(whatobstacle[0], Short2);
                    ChangeEnemy(whatobstacle[1], Long2);
                    ChangeEnemy(whatobstacle[2], Slide2);
                    ChangeEnemy(whatobstacle[3], LongSlide2);
                    MapController.Instance.ChangeMaterial(MapController.Instance.mat_map1);

                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 3:
                    CurrentMap = map4;
                    ChangeJellyPrefab(whatjelly[0], image3);
                    ChangeEnemy(whatobstacle[0], Short3);
                    ChangeEnemy(whatobstacle[1], Long3);
                    ChangeEnemy(whatobstacle[2], Slide3);
                    ChangeEnemy(whatobstacle[3], LongSlide3);
                    MapController.Instance.ChangeMaterial(MapController.Instance.mat_map2);

                    patternNum = 0;
                    p.isMapChange = false;
                    break;
                case 4:
                    CurrentMap = map5;
                    ChangeJellyPrefab(whatjelly[0], image4);
                    ChangeEnemy(whatobstacle[0], Short4);
                    ChangeEnemy(whatobstacle[1], Long4);
                    ChangeEnemy(whatobstacle[2], Slide4);
                    ChangeEnemy(whatobstacle[3], LongSlide4);
                    MapController.Instance.ChangeMaterial(MapController.Instance.mat_map3);

                    patternNum = 0;
                    p.isMapChange = false;
                    break;

            }
        }


        if (CurrentMap != Bonusmap && p.isBonusTime)
        {
            lastPatternum = patternNum;
            lastMap = CurrentMap;

          

            CurrentMap = Bonusmap;
            patternNum = 0;

        }
        if (CurrentMap == Bonusmap && !p.isBonusTime)
        {
            StartCoroutine(WaitingTime(2));
        }


        IEnumerator WaitingTime(float time)
        {
            yield return new WaitForSeconds(time);
            patternNum = lastPatternum;
            CurrentMap = lastMap;
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

    public void ChangeJellyPrefab(GameObject prefab, Sprite newsprite) // code by. �뼮
    {
        SpriteRenderer sp = prefab.GetComponent<SpriteRenderer>();

        if (sp.sprite != null)
        {
            sp.sprite = newsprite;
        }
    }

    public void ChangeEnemy(GameObject prefab, RuntimeAnimatorController Ct)
    {
        Animator anim = prefab.GetComponentInChildren<Animator>();

        if (Ct != null)
        {
            anim.runtimeAnimatorController = Ct;
        }
    }

    IEnumerator spawn() //���� �ڷ�ƾ
    {


        //���� ����
        for (int i = 0; i < jellyAmount; i++)
        {
            int j = 0;

            if (obstacleType == 1) //1�� ������ �Ѿ����� ���̸� ���� ���� ��ġ�� 3 �ø�
            {
                j = 3;

            }
            if (obstacleType == 2)//2�� ������ �Ѿ����� ���̸� ���� ���� ��ġ�� 7 �ø�
            {
                j = 7;
            }
            if (jellyYpos >= j)
            { j = 0; }
            Instantiate(whatjelly[jellytype], SpawnPos[jellyYpos + i + j]);
            // yield return new WaitForSeconds(1 / p.GroundScrollSpeed); //�� ��ũ�� ���ǵ忡 ���缭 ����.
        }
        //���� ����. json���� ���� ���� 0�ϰ�� ���� x
        if (obstacleType >= 1)
        {

            Instantiate(whatobstacle[obstacleType - 1], SpawnPos[obstacle]);

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
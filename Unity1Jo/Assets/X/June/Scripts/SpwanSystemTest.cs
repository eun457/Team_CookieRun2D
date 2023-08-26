using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine.Experimental.GlobalIllumination;

public class SpawnSystemTest : MonoBehaviour
{
    public Transform[] SpawnPos;


    public GameObject[] whatjelly;
    public GameObject[] whatobstacle;


    [SerializeField] int patternNum; //���� ��ȣ
    float LastSpawnTime;

    int jellytype;
    int jellyYpos;
    int jellyAmount;
    int obstacleType;
    int obstacle;

    public string map1 = "Assets/Resources/data.json";
    public string map2 = "Assets/Resources/data.json"; // �� ������ �߰� ����
    public string map3 = "Assets/Resources/data.json"; // �� ������ �߰� ����
    public string map4 = "Assets/Resources/data.json"; // �� ������ �߰� ����

    public void Start()
    {
        patternNum = 0;



    }
    void FixedUpdate()
    {
        //���߿� Ư�� ������ map���� �ϰ� ����
        string jsonFilePath = map1; //���ҽ� ���� �ȿ� �ִ� data�б�



        if (File.Exists(jsonFilePath)) //������ ������ ��
        {
            // JSON ���� �б�
            string jsonContent = File.ReadAllText(jsonFilePath);
            JsonData jsonData = JsonUtility.FromJson<JsonData>(jsonContent); //Json���� ���� ������ Class�� ����


            // ���

            if (Time.time > LastSpawnTime + 3 / GameManager.Instance.GroundScrollSpeed && patternNum < jsonData.index.Count)//���� ���� �ֱ�
            {
                LastSpawnTime = Time.time;
                //Debug.Log(jsonData.index.Count); //countüũ��

                StartCoroutine(spawn());
                jellytype = jsonData.JellyType[patternNum] - 1;     //������ �������� �ڷ�ƾ���� ���� ���� ��������
                jellyYpos = jsonData.JellyYpos[patternNum] - 1;     //������ �������� �ڷ�ƾ���� ���� ���� ��������
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
            yield return new WaitForSeconds(0.7f / GameManager.Instance.GroundScrollSpeed); //�� ��ũ�� ���ǵ忡 ���缭 ����.
        }
        //���� ����. json���� ���� ���� 0�ϰ�� ���� x
        if (obstacleType >= 1)
        {
            for (int i = 0; i < obstacle; i++)
            {
                Instantiate(whatobstacle[obstacleType], SpawnPos[0]);
                yield return new WaitForSeconds(0.7f / GameManager.Instance.GroundScrollSpeed); //�� ��ũ�� ���ǵ忡 ���缭 ����.

            }
        }
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

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static SpawnManager;

public class SpawnManagerV2 : MonoBehaviour
{
    [SerializeField] ItemBox itembox;
    GoogleSheetManager googleSheet;
    Player p;


    [SerializeField] int jellyType;
    [SerializeField] int jellyYpos;
    [SerializeField] int jellyAmount;
    [SerializeField] int obstacleType;
    [SerializeField] int obstaclePos;
    [SerializeField] int ground;





    float LastSpawnTime;
    [SerializeField] float SpawnSpeed;
    [SerializeField] GameObject Spawnpos;

    [SerializeField] int PatternNum;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
       // itembox = GetComponent<ItemBox>();
        PatternNum = 0; //���� �ѹ� �ʱ�ȭ
        p.isMapChange = false;
        p.mapcount = 0;

    }

    float lastPatternum;
    float patternNum;
    string lastMap;
    private void Update()
    {
        googleSheet = GetComponent<GoogleSheetManager>(); //�¶��ο��� �� �������°� ���� ������ ������Ʈ���� ����
        if (p.isMapChange && !p.isBonusTime)
        {
            if (p.mapcount == 0)
            {
                googleSheet.URL = googleSheet.Map1;
                googleSheet.CreateMap();
                p.isMapChange = false;
            }
            if (p.mapcount == 1)
            {
                googleSheet.URL = googleSheet.Map2;
                googleSheet.CreateMap();
                p.isMapChange = false;
            }
        }
        if (googleSheet.URL != googleSheet.BonusMap && p.isBonusTime)
        {
            lastPatternum = patternNum;
            lastMap = googleSheet.URL;
            googleSheet.URL = googleSheet.BonusMap;

            googleSheet.CreateMap();
            patternNum = 0;
            p.DestrtoyObject();
        }
        if (googleSheet.URL == googleSheet.BonusMap && !p.isBonusTime)
        {
            StartCoroutine(WaitingTime(3));
        }


        IEnumerator WaitingTime(float time)
        {
            patternNum = lastPatternum;
            googleSheet.URL = lastMap;
            yield return new WaitForSeconds(time);
            googleSheet.CreateMap();
            p.DestrtoyObject();
        }



    }

    private void FixedUpdate()
    {

        if (Time.time > LastSpawnTime + SpawnSpeed / p.GroundScrollSpeed)//���� ���� �ֱ�
        {
            LastSpawnTime = Time.time;

            if (googleSheet.Listindex == null || googleSheet.Listindex.Count < 1)
            {
                
                Debug.Log("���� ������");
                return;
            }
            if (googleSheet.Listindex != null || googleSheet.Listindex.Count > 0)
            {
                UpdateMapList();
                GetMapValue();
            }


        }

    }

    void GetMapValue()
    {
        int p = 0;
        if (jellyAmount + jellyYpos > 10)
        {

            p = Mathf.Abs(11 - jellyYpos);
        }
        else { p = jellyAmount; }


        for (int i = 0; i < p; i++)
        {

            int j = 0;
            if (obstacleType == 1)
            {
                j = 3;
            }
            if (obstacleType == 2)
            {
                j = 7;
            }
            if (ground > 1)
            { j++; }
            if (jellyYpos >= j)
            { j = 0; }
            Instantiate(itembox.Items[jellyType], transform.GetChild((jellyYpos) + j + i));

        }
        if (obstacleType >= 1)
        {
            Instantiate(itembox.Obstacles[(obstacleType) - 1], transform.GetChild(obstaclePos));

        }
        if (ground > 1)
        {
            Instantiate(itembox.Ground[0], transform.GetChild(ground));

        }
        PatternNum++;
    }
    void UpdateMapList()
    {
        jellyType = googleSheet.ListJellyType[PatternNum];
        jellyYpos = googleSheet.ListJellyYpos[PatternNum];
        jellyAmount = googleSheet.ListJellyAmount[PatternNum];
        obstacleType = googleSheet.ListObstacleType[PatternNum];
        obstaclePos = googleSheet.ListObstacle[PatternNum];
        ground = googleSheet.ListGround[PatternNum];
    }
}

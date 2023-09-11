using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public static MapController Instance;
    private void Awake()
    {
        Instance = this;
    }

    // ���� �� (���� ��)
    public Material[] mat_ovenIn;  
    public Material[] mat_map; // ���� ��
    public Material[] mat_map1;  // ���ؾ� ��
    public Material[] mat_map2; // �ƹ��ų� ����
    public Material[] mat_map3; // �ƹ��ų� ����
                                //public Material[] mat_map4; // ������?

   
    Player p;

    public string CurrentMap;

    string bgmAudioClipPath = "BGM_Map2";


    void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      


        //GameObject Mbonus = GameObject.Find("BonusMap").gameObject;
        //Mbonus?.SetActive(false);  

        SpawnManager.Instance.ChangeJellyPrefab(SpawnManager.Instance.whatjelly[0], SpawnManager.Instance.image0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[0], SpawnManager.Instance.Short0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[1], SpawnManager.Instance.Long0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[2], SpawnManager.Instance.Slide0);
        SpawnManager.Instance.ChangeEnemy(SpawnManager.Instance.whatobstacle[3], SpawnManager.Instance.LongSlide0);
        //SceneManager.LoadScene("DH_MainScene2");      

        if (FindObjectOfType<SpawnManager>() != null)
            SpawnManager.Instance.gameObject.GetComponent<SpawnManager>().enabled = true;  
    }

    void Update()
    {

       
        //if (p.mapcount == 0)
        //{
        //    //CurrentMap = Spawnanager.Instance.map1; //���� ���� �� ���� �� == map1

        //}
        //else if (p.mapcount == 1 && p.isMapChange && !p.isBonusTime)
        //{
        //   // CurrentMap = Spawnanager.Instance.map2;
        //    ChangeMaterial(mat_map);
        //   // p.isMapChange = false;
        //}
        //else if (p.mapcount == 2 && p.isMapChange && !p.isBonusTime)
        //{
        //    //CurrentMap = Spawnanager.Instance.map3;
        //    ChangeMaterial(mat_map1);
        //    //p.isMapChange = false;
        //}
        //else if (p.mapcount == 3 && p.isMapChange && !p.isBonusTime)
        //{
        //    ChangeMaterial(mat_map2);
        //    //CurrentMap = Spawnanager.Instance.map4;
        //    // p.isMapChange = false;
        //}
        //else if (p.mapcount == 4 && p.isMapChange && !p.isBonusTime)  
        //{
        //    ChangeMaterial(mat_map3);
        //    //CurrentMap = Spawnanager.Instance.map4;
        //    // p.isMapChange = false;
        //}
        //else if (p.mapcount == 5 && p.isMapChange && !p.isBonusTime)
        //{
        //    //ChangeMaterial(mat_map4);
        //    //CurrentMap = Spawnanager.Instance.map4;
        //    // p.isMapChange = false;
        //}
    }
    public void ChangeMaterial(Material[] mat_map)
    {
        //Transform[] children = transform.GetComponentsInChildren<Transform>();
        Transform[] children = GameObject.Find("DS_Map").transform.GetComponentsInChildren<Transform>();
    
        foreach (Transform child in children)
        {
            if (child.gameObject.name == "BackGround1")
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null) // mat_map.Length�� �� �ʿ䰡 �ִ°�?
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[0] };
                }
            }
            if (child.gameObject.name == "BackGround2")
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null && mat_map.Length > 0)
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[1] };

                    //BGM���
                    AudioClip bgmAudioClip = GameManager.Instance.LoadAudioClip(bgmAudioClipPath);
                    if (bgmAudioClip != null)
                        SoundManager.Instance.Play(bgmAudioClip, Define.Sound.Bgm);
                }
            }
            if (child.gameObject.name == "BackGround3")
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null && mat_map.Length > 0)
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[2] };
                }
            }
            if (child.gameObject.name == "Ground")
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null && mat_map.Length > 0)
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[3] };
                }
            }
        }
    }
}

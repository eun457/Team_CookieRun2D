using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapControllerJune : MonoBehaviour
{
    Player p; 
    public Material[] mat_ovenIn;
    public Material[] mat_map; // ���� ��
    public Material[] mat_map1;  // ���ؾ� ��
    public Material[] mat_map2; // �ƹ��ų� ����
    public Material[] mat_map3; // �ƹ��ų� ����

    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        ChangeMap();
    }
    private void Update()
    {
        if(p.mapcount == 0)
        {

        }
    }
    
    void ChangeMap()
    {
        Transform background1 = FindChildObjectByName(transform, "BackGround1");


    }
    Transform FindChildObjectByName(Transform parent, string name)
    {
        foreach (Transform child in parent)
        {
            if (child.name == name)
            {
                Debug.Log(name + ": " + child.gameObject.name);
            }
        }
        return null; // ã�� ���� ��� null ��ȯ
    }

}

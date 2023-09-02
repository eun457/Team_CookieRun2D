using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterials : MonoBehaviour
{

    public Material[] mat_map; // �� �̹����� ����� ���׸���
    //public Material[] mat_map2; 
    //public Material[] mat_map3;
    
    string objectName = "BackGround1";
    string objectName1 = "BackGround2";
    string objectName2 = "BackGround3";
    string objectName3 = "Ground";
    

   
    void ChangeMaterial(Material[] mat_map)
    {
        Transform[] children = transform.GetComponentsInChildren<Transform>();

        foreach (Transform child in children)
        {
            if (child.gameObject.name == objectName)
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null && mat_map.Length > 0) // mat_map.Length�� �� �ʿ䰡 �ִ°�?
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[0]};
                }
            }
            if (child.gameObject.name == objectName1)
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null && mat_map.Length > 0)
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[1]};
                }
            }
            if (child.gameObject.name == objectName2)
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null && mat_map.Length > 0)
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[2]};
                }
            }
            if (child.gameObject.name == objectName3)
            {
                MeshRenderer meshRenderer = child.gameObject.GetComponent<MeshRenderer>();
                if (meshRenderer != null && mat_map != null && mat_map.Length > 0)
                {
                    meshRenderer.sharedMaterials = new Material[] { mat_map[3]};
                }
            }
        }
    }
    //public void ChangeMaterial(Material[] material) // ���׸��� �ٲ��ֱ�
    //{
    //    if ((backGround1 != null && backGround2 != null && backGround3 != null
    //        && ground != null && material != null)) // �̹� ����ִٸ� ���ο� ���׸���� �ٲ��ش�.
    //    {
    //        backGround1.materials = new Material[] { material[0] };
    //        backGround2.materials = new Material[] { material[1] };
    //        backGround3.materials = new Material[] { material[2] };
    //        ground.materials = new Material[] { material[3] };
    //    }
    //}
}

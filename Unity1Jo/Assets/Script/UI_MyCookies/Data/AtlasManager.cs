using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AtlasManager : MonoBehaviour //code by. ����
{
    public static AtlasManager instance;

    public SpriteAtlas[] arrAtlas; //Ȥ�� ��ֹ��� SpriteAtlas�� �� �� ������ �迭�� �س���
    public Dictionary<string, SpriteAtlas> dicAtlas = new Dictionary<string, SpriteAtlas>();

    private void Awake()
    {
        AtlasManager.instance = this;

        //Debug.LogFormat("arrAtlas.Length: {0}", arrAtlas.Length);

        for(int i = 0; i < arrAtlas.Length; i++)
        {
            var atlas = arrAtlas[i];

            //���� atlas���ϸ��� (�̸�)Atlas�� �س���, ���ϸ��� Atlas�� ���ŵ� '�̸�'�� Key�� �����
            var atlasName = atlas.name.Replace("Atlas", "");
            dicAtlas.Add(atlasName, atlas);
            
        }
    }

    public SpriteAtlas GetAtlasByName(string name) //Key
    {
        if (dicAtlas.ContainsKey(name))
        {
            return dicAtlas[name];
        }
        else
        {
            Debug.LogFormat("<color=red> key: {0}�� ã�� �� �����ϴ�.</color>", name);
            return null;
        }
    }
}

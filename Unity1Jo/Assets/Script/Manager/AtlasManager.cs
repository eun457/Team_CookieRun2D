using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AtlasManager : SingletonBehaviour<AtlasManager> //code by. ����
{
    public SpriteAtlas[] arrAtlas;
    public Dictionary<string, SpriteAtlas> dicAtlas = new Dictionary<string, SpriteAtlas>();

    private void Awake()
    {
        base.Awake();

        for(int i = 0; i < arrAtlas.Length; i++)
        {
            var atlas = arrAtlas[i];
            var atlasName = atlas.name.Replace("Atlas", ""); //���� atlas���ϸ��� (�̸�)Atlas�� �س���, ���ϸ��� Atlas�� ���ŵ� '�̸�'�� Key�� �����
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

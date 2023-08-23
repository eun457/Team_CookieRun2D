using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class AtlasTestMain : MonoBehaviour
{
    public Button[] arrBtns;
    public Image cookieImg; //����� �� Ÿ���̹���

    public Texture2D[] srcTextures; //�ҽ� �̹���(��Ű)

    void Start()
    {
        for(int i = 0; i < arrBtns.Length; i++)
        {
            var btn = arrBtns[i];
            int index = i; //���� ĸ��
            btn.onClick.AddListener(() => {
                //Ŭ����(���ٽ�)
                //Debug.LogFormat("i: {0}, idx: {1}", i, index); 
                Texture2D texture = srcTextures[index];
                //Sprite�� ����_Sprite.Create(texture, rect, pivot��ġ)
                Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            });
        }
    }

    void Update()
    {
        
    }
}

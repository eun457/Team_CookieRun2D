using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D; //SpriteAtlas ������Ʈ ��뿡 �ʿ�

public class UIMyCookies : MonoBehaviour
{
    public UIScrollView uiScrollView;
    public SpriteAtlas atlas;

    public void Initialize() //��ȭ, �Ǹ޴�, ��ũ�Ѻ� ��� �ʱ�ȭ
    {

        //��ũ�Ѻ� �ʱ�ȭ
        uiScrollView.Initialize();
    }

}

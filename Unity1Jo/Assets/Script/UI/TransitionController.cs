using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionController : MonoBehaviour
{
    // �̱��� ��� static ���� ����, �̷��� ��� ���.

    // �ν����Ϳ��� ������ ��.
    [SerializeField] private Image blackBack; // ȭ�� �� ä�� �̹��� ������Ʈ. (������.)
    [SerializeField] private float time = 2f;  

    // ���� Static �޼ҵ忡�� ����� ��.
    static private Image BlackBack;
    static private float Time;

    static Sequence sequenceFadeInOut;  


    private void Awake()
    {
        BlackBack = blackBack;
        Time = time;

        BlackBack.enabled = false;
        BlackBack.color = new Color(0, 0, 0, 0);     
    }

    private void Start()
    {       
        // ����.
        sequenceFadeInOut = DOTween.Sequence()
            .SetAutoKill(false) // DoTween Sequence�� �⺻������ ��ȸ����. �����Ϸ��� ������.
            .OnRewind(() => // ���� ��. OnStart�� unity Start �Լ��� �Ҹ� �� ȣ���. ������ ����.
            {
                BlackBack.enabled = true;
            })
            .Append(BlackBack.DOFade(1.0f, 0.5f).OnComplete(() => {



            })) // ��ο���. ���� �� ����.  
            .Append(BlackBack.DOFade(0.0f, Time)) // �����. ���� �� ����.          
            .OnComplete(() => // ���� ��.
            {
                BlackBack.enabled = false;  
            });
    }

    static public void Play(Define.Transition transition)
    {
        switch (transition)
        {
            case Define.Transition.Fade: FadeInOut(); break;  
        }
    }

    static private void FadeInOut()
    {
        sequenceFadeInOut.Restart(); // Play()�� �ϸ�, �ѹ� �ۿ� ���� �� ��.   
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UILightRotate : MonoBehaviour //code by. ����
{
    [SerializeField] GameObject Lights;
    [SerializeField] float lightSpeed = 1.5f;
    public void Start()
    {
        RotateLightsEffect();
    }
    public void RotateLightsEffect()
    {
        // 360�� ��� ������
        Lights?.GetComponent<RectTransform>().DORotate(new Vector3(0, 0, 360), lightSpeed, RotateMode.FastBeyond360)
                        .SetEase(Ease.Linear)
                        .SetLoops(-1);          
    }
}

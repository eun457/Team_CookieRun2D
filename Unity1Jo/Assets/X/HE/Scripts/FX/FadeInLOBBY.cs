using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInLOBBY : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 2.0f;
    float alpha = 1;

    [SerializeField] Image panel;

    private void Awake()
    {
        //�۾������� ����Ƽ �ν����Ϳ��� False�س��� Awake()���� true�� ����
        panel.gameObject.SetActive(true);
    }

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        while (panel.color.a > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            panel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        panel.gameObject.SetActive(false);
    }
}

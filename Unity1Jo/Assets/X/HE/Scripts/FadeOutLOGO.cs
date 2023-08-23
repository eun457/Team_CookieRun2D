using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutLOGO : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 1.5f;
    float alpha = 0;

    public Image panel;

    private void Awake()
    {
        //�۾��� ���� ����Ƽ �ν����Ϳ����� ������ Awake()�� ����
        panel.gameObject.SetActive(true);
    }
    void Start()
    {
        StartCoroutine("FadeOut");
    }

    IEnumerator FadeOut()
    {
        while (panel.color.a < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            panel.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }
}

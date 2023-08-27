using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBtnAnimation : MonoBehaviour //code by. ����
{
    public float maxScaleMultiplier = 1.2f;
    public float animationDuration = 1.0f;
    float repeatingTime = 2f;

    private Vector3 originalScale;
    private bool isAnimating = false;

    private void Start()
    {
        originalScale = transform.localScale;
        InvokeRepeating("StartScaleAnimation", 1.0f, repeatingTime);
    }

    private void StartScaleAnimation()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            StartCoroutine(ScaleAnimation());
        }
    }

    private IEnumerator ScaleAnimation()
    {
        //originalScale���� targetScale�� ������ Ȯ��
        float timer = 0.0f;
        Vector3 targetScale = originalScale * maxScaleMultiplier;

        while (timer < animationDuration)
        {
            float t = timer / animationDuration;
            transform.localScale = Vector3.Lerp(originalScale, targetScale, t);

            timer += Time.deltaTime;
            yield return null;
        }

        //targetScale���� originalScale�� ������ ���
        timer = 0.0f;
        while (timer < animationDuration)
        {
            float t = timer / animationDuration;
            transform.localScale = Vector3.Lerp(targetScale, originalScale, t);

            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale;
        isAnimating = false;
    }
}

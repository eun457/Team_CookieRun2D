using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    //code by. ����
    SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] float flashDuration;
    [SerializeField] Material hitMat;
    Material originalmat;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>(); //Player������ Animator���� ��� InChildren���� ����
        originalmat = sr.material;
    }

    IEnumerator FlashFX()
    {
        sr.material = hitMat;
        yield return new WaitForSeconds(flashDuration);
        sr.material = originalmat;
    }
}

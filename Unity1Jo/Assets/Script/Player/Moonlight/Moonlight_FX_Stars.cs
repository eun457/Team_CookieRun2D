using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moonlight_FX_Stars : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 60; //�ʴ� ȸ�� ����

    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.forward, rotationSpeed*Time.deltaTime);
    }
}

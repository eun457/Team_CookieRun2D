using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public float ScrollSpeed = 3f;


    [SerializeField] float posValue;

    Vector2 startPos;
    float newPos;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-ScrollSpeed * Time.deltaTime, 0, 0);
    }

    private void OnBecameInvisible()
    {
        //���� ���� ���� �ڱ� �ڽ� ��ġ���� ���� ��� ������ �̵� (�� ��濡 x = 18)
        transform.position += new Vector3(54, 0, 0);
    }
}

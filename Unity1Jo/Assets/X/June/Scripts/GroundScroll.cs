using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour
{
    public float ScrollSpeed = 3f;


    [SerializeField] float posValue;

    Vector2 startPos;
    float newPos;
    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

 
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);
        if(transform.position.x < -18)
        {
            transform.position += new Vector3(54, 0, 0);
        }
    }

    private void OnBecameInvisible()
    {
        //���� ���� ���� �ڱ� �ڽ� ��ġ���� ���� ��� ������ �̵� (�� ��濡 x = 18)
        //transform.position += new Vector3(54, 0, 0);
    }
}

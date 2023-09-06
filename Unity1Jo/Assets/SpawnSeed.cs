using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSeed : MonoBehaviour
{

    int numberOfObjects = 10; // ������ ���� ������Ʈ�� ��
    float radius = 1f; // ���� ������
    public float delay = 0.2f; // ���� ������ �ð� (��)
    public GameObject Seed;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Player>();
        Invoke("CreateObjects", delay);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        for (float i = -4; i < 5; i++)
    //        {
    //            for (float j = -4; j < 5; j++)
    //            {

    //                Instantiate(Seed, transform.position + new Vector3(i/3, j/3, 0), Quaternion.identity);
    //            }
    //        }

    //    }
    //}
    Player p;





    private void CreateObjects()
    {

        for (int j = 0; j < 3; j++)
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                // �� ������� ��ġ�ϱ� ���� ���� ���
                float angle = i * (360f / numberOfObjects);
                float radians = angle * Mathf.Deg2Rad;

                // ���� �߽ɿ����� ��ġ ���
                float x = Mathf.Cos(radians) * radius;
                float y = Mathf.Sin(radians) * radius;

                // ���� ������Ʈ ����
                Vector3 spawnPosition = transform.position + new Vector3(x, y, 0);
                Instantiate(Seed, spawnPosition, Quaternion.identity);
            }
            radius += 0.3f;
        }
    }
}

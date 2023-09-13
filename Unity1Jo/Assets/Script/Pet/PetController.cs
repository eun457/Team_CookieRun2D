using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public Transform target; // ���� Ÿ���� Ʈ���� ��

    //private float relativeHeigth = 1.0f; // ���� �� y��
    //private float zDistance = -1.0f;// z�� ���� ��� �ʿ� ������.
    //private float xDistance = 1.0f; // x��
    [SerializeField] float _speed = 8f;  // ���󰡴� �ӵ� ª���� Ÿ�ٰ� ���� �����δ�.    

    void Start()
    {

    }

    void Update()   
    {
        //Vector3 newPos = target.position + new Vector3(xDistance, relativeHeigth, -zDistance); // Ÿ�� �������� �ش� ��ġ�� ����.. �� Ÿ�� �ֺ��� ��ġ�� ��ġ�� ��´�.. ������ �Ÿ��� ���ϴ� ���
        Vector3 newPos = target.position ; 
        //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed); //�� �� ������ ���� ���� �����Ѵ�. �̷��� �Ǹ� �־����� ���󰣴�.    
        //transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * dampSpeed); //�� �� ������ ���� ���� �����Ѵ�. �̷��� �Ǹ� �־����� ���󰣴�.    

        transform.position = Vector3.MoveTowards(transform.position, newPos, _speed * Time.deltaTime);  

    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }  
}

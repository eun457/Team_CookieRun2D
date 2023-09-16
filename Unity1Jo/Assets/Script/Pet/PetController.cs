using DG.Tweening;
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

    [SerializeField] bool isUpdownMoving = true;
    [SerializeField] GameObject centerMagnetPos;  

    void Start()
    {
        //StartCoroutine("CoroutineName");
        //Invoke("CoroutineStop", 3); 
    }

    void Update()   
    {
        if (isUpdownMoving)
        {
            Vector3 newPos = target.position;
            transform.position = Vector3.MoveTowards(transform.position, newPos, _speed * Time.deltaTime);

        }
        
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
    public void SetIsUpdownMoving(bool flag)
    {
        isUpdownMoving = flag;
    }
    public void MoveMangetCenterPos()
    {
        transform.DOMove(centerMagnetPos.transform.position, 2).OnComplete(  
            () => {
                MoveReset();  
            });   
    }

    void MoveReset()
    {
        //GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        //Transform petMiddlePos = playerObj.GetComponent<Player>().GetPetMiddlePos();

        //transform.DOMove(petMiddlePos.transform.position, 2).OnComplete(
        //    () => {
        //        isUpdownMoving = true;    
        //    });

        // TODO : ���ʰ� ���߰� �� �� isUpdownMoving = true�� ���ߵ�!    
        isUpdownMoving = true;  
    }

    //IEnumerator CoroutineName()
    //{
    //    int counter = 0;

    //    while (true)
    //    {
    //        Debug.Log(counter);
    //        counter++;
    //        yield return new WaitForSeconds(1);
    //    }
    //}
    //void CoroutineStop() //���� �� 3�ʵڿ� ȣ�� �� �Լ�
    //{
    //    Debug.Log("�ڷ�ƾ ����");
    //    StopCoroutine("CoroutineName");
    //}

}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Player p;
    
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
      

    }

    void Update()
    {
        transform.position += new Vector3(-p.GroundScrollSpeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //if(col.gameObject.CompareTag("Player") && p.isGigantic)
        //{
        //    switch (me.name)
        //    {
        //        case "EnemyShort":
        //            Debug.Log("ƨ�ܳ���");
        //            //transform.position = new Vector3(p.GroundScrollSpeed * Time.deltaTime, -p.GroundScrollSpeed * Time.deltaTime, 0);
        //            //transform.Rotate(0,0,-p.GroundScrollSpeed * Time.deltaTime);
        //                break;
        //        case "EnemyLong":
        //            Debug.Log("ƨ�ܳ���");
        //            //transform.position = new Vector3(p.GroundScrollSpeed * Time.deltaTime, -p.GroundScrollSpeed * Time.deltaTime, 0);
        //            //transform.Rotate(0, 0, -p.GroundScrollSpeed * Time.deltaTime);
        //            break;
        //        case "EnemyLongUp":
        //            Debug.Log("ƨ�ܳ���");
        //            //transform.position = new Vector3(p.GroundScrollSpeed * Time.deltaTime, p.GroundScrollSpeed * Time.deltaTime, 0);
        //            //transform.Rotate(0, 0, -p.GroundScrollSpeed * Time.deltaTime);
        //            break;
        //        case "SlideEnemy":
        //             Debug.Log("ƨ�ܳ���");
        //            //transform.position = new Vector3(p.GroundScrollSpeed * Time.deltaTime, p.GroundScrollSpeed * Time.deltaTime, 0);
        //            //transform.Rotate(0, 0, -p.GroundScrollSpeed * Time.deltaTime);
        //            break;
        //    }
        //}
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

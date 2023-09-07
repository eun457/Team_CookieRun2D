using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigStarTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Item")
            || collision.gameObject.CompareTag("Jelly") ||
            collision.gameObject.CompareTag("Coin") ||
            collision.gameObject.CompareTag("SpawnGround")      
            )
            return;  

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Enemy �� big star �� �浹 ");
            Destroy(collision.gameObject);  
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIResult : MonoBehaviour
{
    public Text totalCoinText; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        totalCoinText.text = string.Format("{0:#,0}", GameManager.Instance.IngameCoin); //���ڸ������� ,���
    }
}

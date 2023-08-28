using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Test1 : ScriptableObject  // ���� ������Ʈ�� ���� �ʿ� X 
{
    public Dictionary<int, string> BonusItemJelly = new Dictionary<int, string>()
  {
        {0,"TestJelly"},
        
    };



    public enum BonusTimeType  // ������ ����
    {
        Jelly = 10,
        O,
        N,
        U,
        S,
        T,
        I,
        M,
        E,

    }

    public string itemName; // �������� �̸�
    public BonusTimeType BonusTimeAlp; // ������ ����
    public Sprite itemImage; // �������� �̹���(�κ� �丮 �ȿ��� ���)
    public GameObject itemPrefab;  // �������� ������ (������ ������ ���������� ��)

}

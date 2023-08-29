using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject  // ���� ������Ʈ�� ���� �ʿ� X 
{
    public Dictionary<int, string> BonusItemJelly = new Dictionary<int, string>()
  {
        {0,"B"},
        {1,"O"},
        {2,"N"},
        {3,"U"},
        {4,"S"},
        {5,"T"},
        {6,"I"},
        {7,"M"},
        {8,"E"},
       
    };



public enum BonusTimeType  // ������ ����
    {
        B,
        O,
        N,
        U,
        S,
        T,
        I,
        M,
        E,
        Jelly,
        Coin,
        Dash,
        Gigantic,
        Magnet,
        Heal,

      
    }

    public string itemName; // �������� �̸�
    public BonusTimeType ItemType; // ������ ����
    public Sprite itemImage; // �������� �̹���(�κ� �丮 �ȿ��� ���)
    public GameObject itemPrefab;  // �������� ������ (������ ������ ���������� ��)


}

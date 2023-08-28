//�÷��̾� �����ϰ� ���ִ� �Ŵ���
//�÷��̾� �����ϰ� ���ִ� �Ŵ���
//�÷��̾� �����ϰ� ���ִ� �Ŵ���
//�÷��̾� �����ϰ� ���ִ� �Ŵ���

using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class PlayerManager : SingletonBehaviour<PlayerManager>
{
    [SerializeField] private GameObject player;
    void Awake()
    {
        base.Awake();
    }
    Player p;
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        
    }
    public GameObject GetPlayer()
    {
        return player;
    }

    [SerializeField] Transform OriginPlayerPos;

    public void SetOriginPlayerPosition()
    {
        if (player.transform.localScale.y > p.OriginalSize.y)
        {
            player.transform.position = OriginPlayerPos.position+new Vector3(0,4,0);
            player.GetComponent<Player>().rb.velocity = Vector2.zero;
        }
        else
        player.transform.position = OriginPlayerPos.position;
        player.GetComponent<Player>().rb.velocity = Vector2.zero;

        //OriginPlayerPos.position = new Vector3(0,0,0);
    }

    

}

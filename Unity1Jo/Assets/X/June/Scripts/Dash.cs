using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Dash : MonoBehaviour
{

    public GameObject[] Ground;//��� �� Ground �迭�� ��������

    private bool isTriggerEneter;

    public GameObject txt;

    Player p;

    [SerializeField] string effectAudioClipPath = "SoundEff_GetItemJelly";
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision) //trigger�� ����� ��
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾���
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.IngameEffect);

            p.DashDuration = p.DashTime;//�뽬 ���ӽð� �ʱ�ȭ

            gameObject.GetComponent<SpriteRenderer>().enabled = false; //������ �̹��� ����


            p.isDashing = true;
            if (p.DashDuration > 0) //�뽬 ���ӽð��� �����ִٸ�.
            {
                p.GroundScrollSpeed = p.OriginalGroundScrollSpeed * 3; //���� �ӵ����� 3�� �������� ���� �־���

            }

            isTriggerEneter = true;

            gameObject.GetComponent<CircleCollider2D>().enabled = false;

            Invoke("DestroySelf", 5); //5�ʵ� ���� ����
        }
    }
    void Update()
    {

        if (p.DashDuration <= 0)
        {
            p.GroundScrollSpeed = p.OriginalGroundScrollSpeed;
            p.isDashing = false;
        }

        if (isTriggerEneter)
        {
            Instantiate(txt, p.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            isTriggerEneter = false;
        }

    }
    private void OnBecameInvisible()
    {
        isTriggerEneter = false;
    }

    void DestroyChild()
    {
        Destroy(transform.GetChild(0));
    }
    void DestroySelf()
    {
        Destroy(gameObject); //������Ű��
    }

  

}

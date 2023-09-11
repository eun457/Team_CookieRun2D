using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gigantic : MonoBehaviour
{
    GameObject player;
    public float Size;
    public GameObject txt;
    private bool isTriggerEneter;

    Player p;

    //����
    [SerializeField] string effectAudioClipPath = "SoundEff_GetItemJelly";
    [SerializeField] string effectAudioClipPath1 = "E_Gigantic";
    [SerializeField] string effectAudioClipPath2 = "E_BacktoOriginScale";
    private void Start()
    {
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        Size = p.GiganticSize; //���Ӹ޴������� ���� �����ϰ� ��
    }

    //private void Start()
    //{
    //    Size = p.GiganticSize; //���Ӹ޴������� ���� �����ϰ� ��
    //}
    private void OnTriggerEnter2D(Collider2D collision) //�÷��̾�� ����� ��
    {
        if (collision.gameObject.CompareTag("Player")) //�÷��̾��� �±װ� ���� ��
        {
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.IngameEffect);

            player = GameObject.FindGameObjectWithTag("Player"); //���ӿ�����Ʈ�� ���� ��� ���ӿ�����Ʈ ����
            gameObject.GetComponent<SpriteRenderer>().enabled = false; //�÷��̾��� �̹��� ����
            p.GiganticDuration = p.GiganticTime; //������ ���� �ð� �ʱ�ȭ

            if (!p.isGigantic) //�Ŵ�ȭ ���°� �ƴ� ��
            {
                player.transform.position += new Vector3(0, Size / 10, 0);// ������ �� �����̱�
                for (int i = 0; i < Size; i++) //���� ������ ��ŭ Ŀ��
                {
                    StartCoroutine(SizeUp()); //������ �� �ϱ�

                    AudioClip effectAudioClip1 = GameManager.Instance.LoadAudioClip(effectAudioClipPath1);
                    if (effectAudioClip1 != null)
                    {
                        Debug.Log("Ŀ���� ����");
                        SoundManager.Instance.Play(effectAudioClip1, Define.Sound.GiganticEffect);
                    }
                }

            }
            p.isGigantic = true;

            isTriggerEneter = true;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Invoke("DestroySelf", 6); //5�� �� ���� ����
        }
    }

    void FixedUpdate()
    {

        if (!p.isGigantic) //�Ŵ�ȭ ���ӽð��� �����ٸ�
        {
           
            if (GameObject.FindGameObjectWithTag("Player").transform.localScale.y > p.OriginalSize.y) //������ ũ��� ���� ũ�Ⱑ ��ġ ���� �ʴ´ٸ�
            {
                StartCoroutine(SizeDown());

                AudioClip effectAudioClip1 = GameManager.Instance.LoadAudioClip(effectAudioClipPath2);
                if (effectAudioClip1 != null)
                {
                    Debug.Log("�۾����� ����");
                    SoundManager.Instance.Play(effectAudioClip1, Define.Sound.GiganticEffect);
                }
            }
        }
        if (isTriggerEneter)
        {
            Instantiate(txt, p.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            isTriggerEneter = false;
        }
    }
    void DestroyChild()
    {
        Destroy(transform.GetChild(0));
    }
    IEnumerator SizeDown()
    {
        GameObject.FindGameObjectWithTag("Player").transform.localScale -= new Vector3(0.1f, 0.1f, 0); //�÷��̾��� ���ý����ϰ� ����

        yield return new WaitForSeconds(0.1f);
    }


    private void OnBecameInvisible()
    {
        isTriggerEneter = false;
    }
    void DestroySelf() //������� ���ư��� �Լ�
    {
        Destroy(gameObject);//���� ������Ʈ ����
    }


    IEnumerator SizeUp()
    {
        player.transform.localScale += new Vector3(0.1f, 0.1f, 0); //�÷��̾��� ���ý����ϰ� 3 ����

        yield return new WaitForSeconds(0.1f);
    }
}

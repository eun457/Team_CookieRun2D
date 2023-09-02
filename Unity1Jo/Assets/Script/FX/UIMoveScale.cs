using DG.Tweening;
using System.Collections;
using UnityEngine;

public class UIMoveScale : MonoBehaviour //code by.����
{
    [SerializeField] GameObject TitleTxt;
    [SerializeField] GameObject Point;
    [SerializeField] GameObject Coin;
    [SerializeField] GameObject Dialogue;
    [SerializeField] GameObject OkBtn;
    [SerializeField] float animationDuration = 0.1f; //Ŀ���� �ִϸ��̼��� ����Ǵ� �ð�
    [SerializeField] float delay = 0.2f; // �� ������Ʈ�� ���� ������ �ð�


    public void Start()
    {
        StartCoroutine(MoveScaleBigger());
    }

    private IEnumerator MoveScaleBigger()
    {
        if (TitleTxt != null)
        {
            //�ٲ� ������ 
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            TitleTxt.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (Point != null)
        {
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            Point.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (Coin != null)
        {
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            Coin.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (Dialogue != null)
        {
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            Dialogue.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (OkBtn != null)
        {
            Vector3 changeScale = new Vector3(1f, 1f, 1f);
            OkBtn.GetComponent<RectTransform>().DOScale(changeScale, animationDuration);
        }
    }
}

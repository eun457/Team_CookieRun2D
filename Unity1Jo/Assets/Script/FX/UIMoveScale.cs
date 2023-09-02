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
    [SerializeField] Transform Player;
    [SerializeField] float animationDuration = 0.1f; //Ŀ���� �ִϸ��̼��� ����Ǵ� �ð�
    [SerializeField] float delay = 0.2f; // �� ������Ʈ�� ���� ������ �ð�
    public Vector3 targetScale = new Vector3(1, 1, 1);


    public void Start()
    {
            StartCoroutine(MoveScaleBigger());
    }

    private IEnumerator MoveScaleBigger()
    {
        if (TitleTxt != null)
        {
            TitleTxt.GetComponent<RectTransform>().DOScale(targetScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (Point != null)
        {
            Point.GetComponent<RectTransform>().DOScale(targetScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (Coin != null)
        {
            Coin.GetComponent<RectTransform>().DOScale(targetScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (Dialogue != null)
        {
            Dialogue.GetComponent<RectTransform>().DOScale(targetScale, animationDuration);
        }

        yield return new WaitForSeconds(delay);

        if (Player != null)
        {
            Vector3 changeScale = new Vector3(2.2f, 2.2f, 1f);
            Player.DOScale(changeScale, 0.3f);
        }

        yield return new WaitForSeconds(delay);

        if (OkBtn != null)
        {
            OkBtn.GetComponent<RectTransform>().DOScale(targetScale, animationDuration);
        }
    }
}

using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYPETS_Main : MonoBehaviour
{
    public UIMyPets uiMyPets;
    public MYPETS_UIScrollView petScrollView;

    [Header("Popup Data")]
    [SerializeField] GameObject UI_BuyPopup;
    [SerializeField] GameObject ui_CheckPopupBox;
    [SerializeField] GameObject ui_CautionPopupBox;
    [SerializeField] private Vector3 targetScale = new Vector3(1.2f, 1.2f, 1.2f); // Ȯ���� ������ ��
    [SerializeField] private Vector3 originScale = new Vector3(1, 1, 1); // Ȯ���� ������ ��
    [SerializeField] private float animationDuration = 0.2f; // �ִϸ��̼� ���� �ð�  

    [Header("Audio Sound ")]
    //[SerializeField] string bgmAudioClipPath = "";
    [SerializeField] string effectAudioClipPath = "E_ClickBtn";
    private void Start()
    {
        UI_DataManager.instance.LoadPetsData();

        //���ù�ư Ŭ�� ��,
        EventManager.instance.onSelectBtnClick = (id) =>
        {
            var data = UI_DataManager.instance.GetPetsData(id);

            //�ڷΰ��� ������ LOBBY������ �ٲ�鼭 �ش� ĳ���Ͱ� ���
            if (UserDataManager.Instance.GetHasPet(id) == 0) // �� �Ȱ����� ������ ���� 
                return;

            UserDataManager.Instance.SetSelectPetID(id);
            UIScrollViewPetsSelect beforeCheckpetComponent = petScrollView.GetPetComponentList()?.Find(item => item.GetCheck() == true); // ���� üũ�Ǿ��ִ� �� ������Ʈ ������ 
            UIScrollViewPetsSelect afterCheckpetComponent = petScrollView.GetPetComponentList()?.Find(item => item.GetID() == data.id);  // ���õ� �� ������Ʈ ������ 
            beforeCheckpetComponent?.RefreshCheck(); // ���� refresh 
            afterCheckpetComponent?.RefreshCheck();  // ���� refresh 


            //Effect���
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
            {
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
            }
        };

        //���Ź�ư Ŭ�� ��,
        EventManager.instance.onBuyBtnClick = (id) =>
        {
            var data = UI_DataManager.instance.GetPetsData(id);
            Debug.LogFormat("{0},{1},{2}", data.id, data.name, data.price);

            float totCoin = GameManager.Instance.totalCoin; // total coin ������ 
            Debug.Log($"totCoin : {totCoin}");

            if (totCoin >= data.price)
            {
                UI_BuyPopup.gameObject.SetActive(true);

                GameObject checkPopupBox = Instantiate(ui_CheckPopupBox);   // �������� popup ���� (�ش� ������ ��ġ : Asset/Prefabs/UI/Popup)
                checkPopupBox.transform.SetParent(UI_BuyPopup.transform);   // �θ� ���� 
                checkPopupBox.GetComponent<RectTransform>().localPosition = Vector2.zero;   // position ���� 
                checkPopupBox.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); // scale ���� 

                // ID, price, view ��������   
                UI_CheckPopupBox checkComponent = checkPopupBox.GetComponent<UI_CheckPopupBox>();
                checkComponent.SetPetID(data.id);
                checkComponent.SetPetPrice(data.price);
                checkComponent.SetPetScrollView(petScrollView);
                checkComponent.SetPopupType(Define.PopupType.Pet);  

                // popup animation 
                checkPopupBox.GetComponent<RectTransform>().DOScale(targetScale, animationDuration).OnComplete(() =>
                {
                    checkPopupBox.GetComponent<RectTransform>().DOScale(originScale, animationDuration);
                });

            }
            else
            {
                UI_BuyPopup.gameObject.SetActive(true);

                GameObject cautionPopupBox = Instantiate(ui_CautionPopupBox);   // �������� popup ����  (�ش� ������ ��ġ : Asset/Prefabs/UI/Popup)
                cautionPopupBox.transform.SetParent(UI_BuyPopup.transform);     // �θ� ���� 
                cautionPopupBox.GetComponent<RectTransform>().localPosition = Vector2.zero; // position ���� 
                cautionPopupBox.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1); // scale ���� 

                // popup animation 
                cautionPopupBox.GetComponent<RectTransform>().DOScale(targetScale, animationDuration).OnComplete(() =>
                {
                    cautionPopupBox.GetComponent<RectTransform>().DOScale(originScale, animationDuration);
                });

                Debug.Log("������ �����մϴ�.");
            }

            //Effect���
            AudioClip effectAudioClip = GameManager.Instance.LoadAudioClip(effectAudioClipPath);
            if (effectAudioClip != null)
            {
                SoundManager.Instance.Play(effectAudioClip, Define.Sound.Effect);
            }
        };

        uiMyPets.Initialize();
    }
}

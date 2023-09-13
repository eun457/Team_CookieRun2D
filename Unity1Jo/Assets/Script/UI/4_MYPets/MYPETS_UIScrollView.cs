using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MYPETS_UIScrollView : MonoBehaviour
{
    [SerializeField] Transform contentTrans;
    [SerializeField] GameObject petsPrefab;
    [SerializeField] List<UIScrollViewPetsSelect> PetsComponentList = new List<UIScrollViewPetsSelect>();

    private void Awake()
    {
        foreach (Transform child in contentTrans.transform)
            GameObject.Destroy(child.gameObject);   
    }
    public void Initialize()
    {
        List<MyPetsData> list = UI_DataManager.instance.GetMypetsDatas();

        foreach (MyPetsData data in list)
        {
            //create
            AddPets(data);
            Debug.Log("�� �����յ� ����");
        }
    }
    public void AddPets(MyPetsData data)
    {
        var go = Instantiate(petsPrefab, contentTrans);
        UIScrollViewPetsSelect pets = go.GetComponent<UIScrollViewPetsSelect>();  
        pets.Initialize(data);

        //�� ��ư�� ������ �ش� pets�� id�� EventManager���� ����
        pets.selectBtn.onClick.AddListener(() => {
            EventManager.instance.onSelectBtnClick(pets.GetID());
        });
        pets.buyBtn.onClick.AddListener(() => {
            EventManager.instance.onBuyBtnClick(pets.GetID());
        });

        // ���ó�� 
        if (UserDataManager.Instance.GetHasPet(data.id) == 0) // ��Ű �Ȱ����� ���� 
        {
            pets.SetLock(true);
        }
        else
        {
            pets.SetLock(false);
        }

        PetsComponentList.Add(pets);  

    }
    public List<UIScrollViewPetsSelect> GetPetComponentList()
    {
        return PetsComponentList;
    }
}

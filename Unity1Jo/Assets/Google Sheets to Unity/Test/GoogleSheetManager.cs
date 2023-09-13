
using GoogleSheetsToUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.Events;
using UnityEngine.Networking;

public class GoogleSheetManager : MonoBehaviour
{
    //const string URL = "https://docs.google.com/spreadsheets/d/1cd4s_Ctc3_bfb48O4b0rgP9w0N2JHqRKPjTWFJfiAg4/export?format=tsv";
    public string Map1 = "https://docs.google.com/spreadsheets/d/1cd4s_Ctc3_bfb48O4b0rgP9w0N2JHqRKPjTWFJfiAg4/export?format=tsv";
    public string Map2 = "https://docs.google.com/spreadsheets/d/1cd4s_Ctc3_bfb48O4b0rgP9w0N2JHqRKPjTWFJfiAg4/export?format=tsv&gid=1732901124";
    public string BonusMap = "https://docs.google.com/spreadsheets/d/1cd4s_Ctc3_bfb48O4b0rgP9w0N2JHqRKPjTWFJfiAg4/export?format=tsv&gid=2046324272";

    public string URL;
    public List<int> Listindex;
    public List<int> ListJellyType;
    public List<int> ListJellyYpos;
    public List<int> ListJellyAmount;
    public List<int> ListObstacleType;
    public List<int> ListObstacle;
    public List<int> ListGround;

    
    public void Start()
    {
        URL = Map1;
        CreateMap();
    }

    public void CreateMap()
    {
        
        Listindex = new List<int>();
        ListJellyType = new List<int>();
        ListJellyYpos = new List<int>();
        ListJellyAmount = new List<int>();
        ListObstacleType = new List<int>();
        ListObstacle = new List<int>();
        ListGround = new List<int>();
        StartCoroutine("start");
    }

    IEnumerator start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;

        string[] lines = data.Split('\n'); // �ٺ��� 


        for (int i = 1; i < lines.Length; i++)
        {
            string[] values = lines[i].Split('\t'); // ������ ���е� ��.

            for (int j = 0; j < values.Length; j++)
            {
                // ������ 0���� ��ü�մϴ�.
                if (string.IsNullOrEmpty(values[j]))
                {
                    values[j] = "0";
                }
            }

            string modifiedLine = string.Join("\t", values); // ������ ���� �ٽ� ��ħ
            lines[i] = modifiedLine;
        }

        data = string.Join("\n", lines); // ������ ���� �ٽ� ��ħ
        //Debug.Log(data);


        string[] lineline = data.Split('\n'); // �ٺ��� 

        for (int i = 1; i < lineline.Length; i++)
        {
            string[] values = lineline[i].Split('\t'); // ������ ���е� ��.

            //Debug.Log(values[0]);

            if (values[0] != null)
                Listindex.Add(int.Parse(values[0]));
            if (values[1] != null)
                ListJellyType.Add(int.Parse(values[1]));
            if (values[2] != null)
                ListJellyYpos.Add(int.Parse(values[2]));
            if (values[3] != null)
                ListJellyAmount.Add(int.Parse(values[3]));
            if (values[4] != null)
                ListObstacleType.Add(int.Parse(values[4]));
            if (values[5] != null)
                ListObstacle.Add(int.Parse(values[5]));
            if (values[6] != null)
                ListGround.Add(int.Parse(values[6]));

            string modifiedLine = string.Join("\t", values); // ������ ���� �ٽ� ��ħ
            lineline[i] = modifiedLine;
        }
    }


}

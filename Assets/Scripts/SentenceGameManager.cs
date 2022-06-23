using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SentenceGameManager : MonoBehaviour
{
    public Canvas canvas1;  //캔버스
    public Canvas canvas2;

    public List<TextMeshProUGUI> btnText1;
    public List<TextMeshProUGUI> btnText2;

    private List<string> wordList1;  //원래 리스트
    private List<string> wordList2;  //원래 리스트

    private List<string> mixList1;  //랜덤 돌린 리스트
    private List<string> mixList2;  //랜덤 돌린 리스트

    private List<string> clickChoicesList = new List<string>();
    public List<TextMeshProUGUI> clickChoicesList1;  //사용자가 선택한 리스트
    public List<TextMeshProUGUI> clickChoicesList2;  //사용자가 선택한 리스트

    // Start is called before the first frame update
    void Start()
    {
        canvas2.enabled = false;
        canvas1.enabled = true;
        wordList1 = new List<string>() { "저의", "발표주제는", "디지털 치료제" };
        wordList2 = new List<string>() { "독성 및 부작용", "저렴한 비용으로", "대량 공급이" };

        Mix();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Mix()  //wordList1이랑 wordList2 둘다 믹스하기
    {
        List<string> newList1 = new List<string>();
        List<string> newList2 = new List<string>();

        for(int i=0; i<3; i++)
        {
            int rand = Random.Range(0, wordList1.Count);
            newList1.Add(wordList1[rand]);
            wordList1.RemoveAt(rand);
        }
        mixList1 = newList1;

        for(int i=0; i<3; i++)
        {
            int rand = Random.Range(0, wordList2.Count);
            newList2.Add(wordList2[rand]);
            wordList2.RemoveAt(rand);
        }
        mixList2 = newList2;

        AppendButtonText();
    }

    void AppendButtonText()  //랜덤으로 돌린 문자열 버튼에 붙이기
    {
        for(int i=0; i<3; i++)
        {
            btnText1[i].text = mixList1[i];
        }

        for (int i = 0; i < 3; i++)
        {
            btnText2[i].text = mixList2[i];
        }
    }

    public void ClickChoiceButton()
    {
        Debug.Log("클릭!");
        GameObject currentObj = EventSystem.current.currentSelectedGameObject;
        string text = currentObj.GetComponentInChildren<TextMeshProUGUI>().text;
        Debug.Log(text);
        clickChoicesList.Add(text);

        if (clickChoicesList.Count == 3)
            ShowResult(clickChoicesList);
    }

    void ShowResult(List<string> choice)
    {
        if (DecideAnswer(choice))
        {
            Debug.Log("Correct!");
            clickChoicesList.Clear();
        }
        else
        {
            Debug.Log("Wrong! try again");
            clickChoicesList.Clear();
        }
    }


    bool DecideAnswer(List<string> choice)
    {
        if (canvas1.enabled)
        {
            wordList1 = new List<string>() { "저의", "발표주제는", "디지털 치료제" };
            for(int i=0; i<3; i++)
            {
                if (choice[i].ToString() != wordList1[i].ToString())
                    return false;
            }
            clickChoicesList.Clear();
            canvas1.enabled = false;
            canvas2.enabled = true;
            return true;
            
        }
        else if (canvas2.enabled)
        {
            wordList2 = new List<string>() { "독성 및 부작용", "저렴한 비용으로", "대량 공급이" };
            for (int i = 0; i < 3; i++)
            {
                if (choice[i].ToString() != wordList2[i].ToString())
                    return false;
            }
        }
        return true;
    }
}

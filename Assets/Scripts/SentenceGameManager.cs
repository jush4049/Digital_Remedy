using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SentenceGameManager : MonoBehaviour
{
    public Canvas canvas1;  //ĵ����
    public Canvas canvas2;

    public List<TextMeshProUGUI> btnText1;
    public List<TextMeshProUGUI> btnText2;

    private List<string> wordList1;  //���� ����Ʈ
    private List<string> wordList2;  //���� ����Ʈ

    private List<string> mixList1;  //���� ���� ����Ʈ
    private List<string> mixList2;  //���� ���� ����Ʈ

    private List<string> clickChoicesList = new List<string>();
    public List<TextMeshProUGUI> clickChoicesList1;  //����ڰ� ������ ����Ʈ
    public List<TextMeshProUGUI> clickChoicesList2;  //����ڰ� ������ ����Ʈ

    // Start is called before the first frame update
    void Start()
    {
        canvas2.enabled = false;
        canvas1.enabled = true;
        wordList1 = new List<string>() { "����", "��ǥ������", "������ ġ����" };
        wordList2 = new List<string>() { "���� �� ���ۿ�", "������ �������", "�뷮 ������" };

        Mix();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Mix()  //wordList1�̶� wordList2 �Ѵ� �ͽ��ϱ�
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

    void AppendButtonText()  //�������� ���� ���ڿ� ��ư�� ���̱�
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
        Debug.Log("Ŭ��!");
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
            wordList1 = new List<string>() { "����", "��ǥ������", "������ ġ����" };
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
            wordList2 = new List<string>() { "���� �� ���ۿ�", "������ �������", "�뷮 ������" };
            for (int i = 0; i < 3; i++)
            {
                if (choice[i].ToString() != wordList2[i].ToString())
                    return false;
            }
        }
        return true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    public List<TextMeshProUGUI> answerList1; // ������ �ؽ�Ʈ�� �Էµ� answer ����Ʈ
    private int currentAnswerIndex1; // ���õ� Answer�� Text�� ����ֱ����� index ����
    private List<string> initialText1 = new List<string>(); // �ʱ⿡ �ԷµǾ��ִ� ���ڿ��� ������ ����Ʈ

    public List<TextMeshProUGUI> answerList2; // ������ �ؽ�Ʈ�� �Էµ� answer ����Ʈ
    private int currentAnswerIndex2; // ���õ� Answer�� Text�� ����ֱ����� index ����
    public List<string> initialText2 = new List<string>(); // �ʱ⿡ �ԷµǾ��ִ� ���ڿ��� ������ ����Ʈ

    public List<Button> btnList1;
    public List<Button> btnList2;

    public GameObject correctAnswerObject;
    public GameObject wrongAnswerObject;
    public GameObject wrongAnswerObject2;
    public GameObject GoSceneButton;
    private int currentCanvasNumber;

    // Start is called before the first frame update
    void Start()
    {
        GoSceneButton.SetActive(false);
        currentCanvasNumber = 1;

        currentAnswerIndex1 = 0;

        canvas2.enabled = false;
        canvas1.enabled = true;
        wordList1 = new List<string>() { "����", "��ǥ������", "������ ġ����" };
        wordList2 = new List<string>() { "���� �� ���ۿ�", "������ �������", "�뷮 ������" };

        Mix();
        loadInitialText();
    }

    public void CheckAndOnAllButton()
    {
        // ��� ��ư���� ��Ȱ��ȭ �Ǿ��ִ��� �˻�
        if (canvas1.enabled)
        {
            for (int i = 0; i < btnList1.Count; i++)
            {
                Debug.Log(i + "Ȱ��ȭ!");
                if (btnList1[i].interactable == true)
                    return;
            }
            OnButtonInteractable(btnList1); // ��ư�� ��Ȱ��ȭ
        }
        else if (canvas2.enabled)
        {
            for (int i = 0; i < btnList2.Count; i++)
            {
                if (btnList2[i].interactable == true)
                    return;
            }
            OnButtonInteractable(btnList2); // ��ư�� ��Ȱ��ȭ
        }

    }

    private void OnButtonInteractable(List<Button> btnList)
    {
        Debug.Log("��ư ��Ȱ��ȭ!");
        for (int i = 0; i < btnList.Count; i++)
            btnList[i].interactable = true;
        GoSceneButton.SetActive(true);
    }

    private void loadInitialText() // answerList�� text������ initailText�� ����
    {
        for (int i = 0; i < answerList1.Count; i++)
        {
            Debug.Log(answerList1[i].text);
            initialText1.Add(answerList1[i].text);
        }

        for (int i = 0; i < answerList2.Count; i++)
        {
            initialText2.Add(answerList2[i].text);
        }
    }

    private void resetAnswerText()
    {
        if(canvas1.enabled)
        {
            for (int i = 0; i < answerList1.Count; i++)
                answerList1[i].text = initialText1[i];
        }
        else if (canvas2.enabled)
        {
            for (int i = 0; i < answerList2.Count; i++)
                answerList2[i].text = initialText2[i];
        }
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

        if(canvas1.enabled)
            answerList1[currentAnswerIndex1].text = text; // ���� ���� ������ ����ĭ�� �־���(cnavas1)
        else
            answerList2[currentAnswerIndex2].text = text; // ���� ���� ������ ����ĭ�� �־���(canvas2)

        Debug.Log(text);
        

        clickChoicesList.Add(text);

        if (clickChoicesList.Count == 3)
            ShowResult(clickChoicesList);

        if (currentAnswerIndex1 < answerList1.Count - 1) // ��� ����ĭ�� �Է��� �ȵǾ����� 
            currentAnswerIndex1++; // ����ĭ���� �ε����� �Ű���
        else // �� �Է��� �Ǿ������� 0���� ó��
            currentAnswerIndex1 = 0;

        // ���� ������ó���� canvas2������ �Ѱ�
        if (currentAnswerIndex2 < answerList2.Count - 1)
            currentAnswerIndex2++;
        else 
            currentAnswerIndex2 = 0;

    }
    public void GoScene()
    {
        SceneManager.LoadScene("Chapter5");
    }
    void ShowResult(List<string> choice)
    {
        if (DecideAnswer(choice)) // ����
        {
            Debug.Log("Correct!");

            if(currentCanvasNumber == 2) //canvas2�� Ȱ��ȭ�����϶� �����̸�
                correctAnswerObject.SetActive(true); // ���� �г� Ȱ��ȭ

            clickChoicesList.Clear();

            currentCanvasNumber++;

        }

        else // ����
        {
            Debug.Log("Wrong! try again");

            wrongAnswerObject.SetActive(true); // �����г� Ȱ��ȭ(Canvas1)
            wrongAnswerObject2.SetActive(true); // �����г� Ȱ��ȭ(Canvas2)

            resetAnswerText(); // �ʱⰪ���� �����Է�ĭ�� �ʱ�ȭ����
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

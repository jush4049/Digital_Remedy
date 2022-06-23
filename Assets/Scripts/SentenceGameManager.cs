using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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

    public List<TextMeshProUGUI> answerList1; // 선택한 텍스트가 입력될 answer 리스트
    private int currentAnswerIndex1; // 선택된 Answer을 Text에 집어넣기위한 index 변수
    private List<string> initialText1 = new List<string>(); // 초기에 입력되어있던 문자열을 저장할 리스트

    public List<TextMeshProUGUI> answerList2; // 선택한 텍스트가 입력될 answer 리스트
    private int currentAnswerIndex2; // 선택된 Answer을 Text에 집어넣기위한 index 변수
    public List<string> initialText2 = new List<string>(); // 초기에 입력되어있던 문자열을 저장할 리스트

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
        wordList1 = new List<string>() { "저의", "발표주제는", "디지털 치료제" };
        wordList2 = new List<string>() { "독성 및 부작용", "저렴한 비용으로", "대량 공급이" };

        Mix();
        loadInitialText();
    }

    public void CheckAndOnAllButton()
    {
        // 모든 버튼들이 비활성화 되어있는지 검사
        if (canvas1.enabled)
        {
            for (int i = 0; i < btnList1.Count; i++)
            {
                Debug.Log(i + "활성화!");
                if (btnList1[i].interactable == true)
                    return;
            }
            OnButtonInteractable(btnList1); // 버튼들 재활성화
        }
        else if (canvas2.enabled)
        {
            for (int i = 0; i < btnList2.Count; i++)
            {
                if (btnList2[i].interactable == true)
                    return;
            }
            OnButtonInteractable(btnList2); // 버튼들 재활성화
        }

    }

    private void OnButtonInteractable(List<Button> btnList)
    {
        Debug.Log("버튼 재활성화!");
        for (int i = 0; i < btnList.Count; i++)
            btnList[i].interactable = true;
        GoSceneButton.SetActive(true);
    }

    private void loadInitialText() // answerList의 text값들을 initailText에 저장
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

        if(canvas1.enabled)
            answerList1[currentAnswerIndex1].text = text; // 현재 누른 정답을 정답칸에 넣어줌(cnavas1)
        else
            answerList2[currentAnswerIndex2].text = text; // 현재 누른 정답을 정답칸에 넣어줌(canvas2)

        Debug.Log(text);
        

        clickChoicesList.Add(text);

        if (clickChoicesList.Count == 3)
            ShowResult(clickChoicesList);

        if (currentAnswerIndex1 < answerList1.Count - 1) // 모든 정답칸에 입력이 안되었을때 
            currentAnswerIndex1++; // 다음칸으로 인덱스를 옮겨줌
        else // 다 입력이 되어있으면 0으로 처리
            currentAnswerIndex1 = 0;

        // 위와 동일한처리를 canvas2용으로 한것
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
        if (DecideAnswer(choice)) // 정답
        {
            Debug.Log("Correct!");

            if(currentCanvasNumber == 2) //canvas2가 활성화상태일때 정답이면
                correctAnswerObject.SetActive(true); // 정답 패널 활성화

            clickChoicesList.Clear();

            currentCanvasNumber++;

        }

        else // 오답
        {
            Debug.Log("Wrong! try again");

            wrongAnswerObject.SetActive(true); // 오답패널 활성화(Canvas1)
            wrongAnswerObject2.SetActive(true); // 오답패널 활성화(Canvas2)

            resetAnswerText(); // 초기값으로 정답입력칸을 초기화해줌
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

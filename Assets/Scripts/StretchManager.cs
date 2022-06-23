using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StretchManager : MonoBehaviour
{
    [SerializeField] GameObject successWindow, failWindow;  // 결과창
    [SerializeField]
    private Image humanImage;   // 스트레칭 사진
    [SerializeField]
    private TextMeshProUGUI instruction;    // 지시문 텍스트
    [SerializeField]
    private GameObject choices;     // 선택지 버튼 모음
    [SerializeField]
    private List<GameObject> buttonList;    // 화면에 배치된 선택지 버튼 리스트

    [SerializeField]
    private List<Sprite> imageList; // 스트레칭 사진 리스트
    [SerializeField]
    private List<string> instructionList;   // 지시문 리스트
    [SerializeField]
    private int stretchTime;    // 스트레칭 시간
    [SerializeField]
    private int stretchNum;  // 스트레칭할 개수


    private List<GameObject> correctChoicesList;    // 선택지 순서 정답 리스트
    private List<GameObject> clickChoicesList;       // 클릭한 선택지 리스트

    private List<int> orderList;    // 스트레칭 순서
    private int stretchKind;     // 스트레칭 종류

    // Start is called before the first frame update
    void Start()
    {
        stretchKind = imageList.Count;

        orderList = new List<int>();
        correctChoicesList = new List<GameObject>();
        clickChoicesList = new List<GameObject>();
        
        SelectOrder();  // 스트레치 순서 정하기
    }

    private void SelectOrder()
    {
        int idx;
        System.Random random = new System.Random();
        while (orderList.Count < stretchNum)
        {
            idx = random.Next(stretchKind);
            if (orderList.Exists(x => x == idx))
                continue;
            orderList.Add(idx);
        }
        StartCoroutine("SetImageCoroutine");
    }

    IEnumerator SetImageCoroutine()
    {
        yield return new WaitForSeconds(stretchTime);
        for (int i = 0; i < stretchNum; i++)
        {
            humanImage.GetComponent<Image>().sprite = imageList[orderList[i]];
            instruction.text = instructionList[orderList[i]];
            yield return new WaitForSeconds(stretchTime);
        }
        SetChoices();
        ShowChoices();
    }

    // 물체가 다 날아간 후 선택지 보여주기
    private void ShowChoices()
    {
        choices.SetActive(true);
    }

    // 선택지에 이미지 세팅
    private void SetChoices()
    {
        GameObject button;
        System.Random random = new System.Random();
        foreach (int idx in orderList)       // 정답 이미지 선택지에 세팅
        {
            do
            {
                button = buttonList[random.Next(buttonList.Count)];
            } while (correctChoicesList.Exists(x => x == button));
            correctChoicesList.Add(button);
            button.transform.Find("Image").GetComponent<Image>().sprite = imageList[idx];
        }
    }

    // 선택지 버튼 클릭
    public void ClickChoiceButton()
    {
        Debug.Log("클릭!");
        GameObject currentObj = EventSystem.current.currentSelectedGameObject;
        if (!clickChoicesList.Exists(x => x == currentObj))
        {
            clickChoicesList.Add(currentObj);
            TextMeshProUGUI order = currentObj.transform.Find("Order").GetComponent<TextMeshProUGUI>();
            order.text = clickChoicesList.Count.ToString();
        }

        ShowResult();
    }

    private void ShowResult()
    {
        if (clickChoicesList.Count == stretchNum) // 모두 선택했으면 정답인지 확인
        {
            if (DecideAnswer())
            {
                successWindow.SetActive(true);
            }
            else
            {
                failWindow.SetActive(true);
            }
        }
    }

    private bool DecideAnswer()
    {
        for (int i = 0; i < stretchNum; i++)
        {
            if (!(clickChoicesList[i] == correctChoicesList[i]))
                return false;
        }
        return true;
    }

    public void GoScene()
    {

    }

    public void Restart()
    {
        failWindow.SetActive(false);

        // 리스트 초기화
        orderList = new List<int>();
        correctChoicesList = new List<GameObject>();
        clickChoicesList = new List<GameObject>();

        // 정답 맞추기 창 초기화
        choices.SetActive(false);
        foreach (GameObject btn in buttonList)  // 클릭 순서 표시 텍스트 초기화
            btn.transform.Find("Order").GetComponent<TextMeshProUGUI>().text = "";

        SelectOrder();  // 스트레치 순서 정하기
    }
}

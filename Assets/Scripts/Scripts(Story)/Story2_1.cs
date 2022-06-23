using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story2_1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI NameText; // 등장인물 이름 텍스트
    public TextMeshProUGUI ScriptText; // 대사 텍스트
    public string writerText = "";

    public GameObject InBusImage;
    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키
    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(StoryOn());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var element in skipButton) // 버튼 검사
        {
            if (Input.GetKeyDown(element))
            {
                isButtonClicked = true;
            }
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData) // 버튼을 누를 시
    {
        isButtonClicked = true;
    }
    public void OnPointerUp(PointerEventData pointerEventData) // 버튼을 눌렀다가 뗄 시
    {

    }
    // 텍스트 타이핑 제거 버전
    IEnumerator NormalScript(string narrator, string narration)
    {
        NameText.text = narrator;
        writerText = "";

        writerText += narration;
        ScriptText.text = writerText;
        yield return null;

        //키를 다시 누를 떄 까지 무한정 대기
        while (true)
        {
            if (isButtonClicked)
            {
                isButtonClicked = false;
                break;
            }
            yield return null;
        }
    }

    IEnumerator StoryOn()
    {
        InBusImage.SetActive(true);
        yield return StartCoroutine(NormalScript("주인공", "후우......하.."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 서서히 마음이 안정되어 가고 있다."));
        yield return StartCoroutine(NormalScript("나레이션", "하지만 여전히 주변은 사람들로 가득차 있었다."));
        yield return StartCoroutine(NormalScript("주인공", "으으... 안되겠어 이 상황에서 벗어나야돼.."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 눈을 감고 지금 떠오르는 물체 3가지를 상상해본다."));
        yield return StartCoroutine(NormalScript("나레이션", "이어서 '시각 게임'을 시작합니다."));
        SceneManager.LoadScene("Sight");
    }

    
}
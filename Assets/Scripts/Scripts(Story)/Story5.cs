using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story5 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // 등장인물 이름 텍스트
    public Text ScriptText; // 대사 텍스트
    public string writerText = "";

    public GameObject SchoolRestaurantImage;
    public GameObject FoodImage;
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
        FoodImage.SetActive(false);
        SchoolRestaurantImage.SetActive(true);
        yield return StartCoroutine(NormalScript("나레이션", "#5 학교 점심 시간"));
        yield return StartCoroutine(NormalScript("나레이션", "발표를 무사히 마친 주인공은 맘 편히 식사할 수 있었다."));
        FoodImage.SetActive(true);
        yield return StartCoroutine(NormalScript("친구", "오늘 너 멋있었어~! 발표 잘하더라"));
        yield return StartCoroutine(NormalScript("주인공", "고마워 히힛.."));
        FoodImage.SetActive(false);
        yield return StartCoroutine(NormalScript("나레이션", "즐겁게 점심을 먹은 뒤 주인공은 아침에 챙겨온 약을 꺼낸다."));
        yield return StartCoroutine(NormalScript("친구", "근데 그 약 있잖아, 언제까지 먹어야 하는거야?"));
        yield return StartCoroutine(NormalScript("주인공", "으응..? 그래도 다 나을때까진 먹어야 하지 않을까.."));
        yield return StartCoroutine(NormalScript("친구", "하지만 너무 약에만 의존하는 것도 좋지 않다고 들었거든.."));
        yield return StartCoroutine(NormalScript("친구", "넌 이런거 없이도 충분히 이겨낼 수 있을거야~ 헤헤"));
        yield return StartCoroutine(NormalScript("주인공", "그럴까..?"));
        yield return StartCoroutine(NormalScript("주인공", "주인공은 약을 복용하며 여러가지 생각에 잠긴다."));
        yield return StartCoroutine(NormalScript("나레이션", "다섯 번째 게임 '약 먹기 게임'을 시작합니다."));
        SceneManager.LoadScene("TakeMedicineGame");
    }
}
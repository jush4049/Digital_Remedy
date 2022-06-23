using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
        yield return StartCoroutine(NormalScript("나레이션", "#2 버스 정류장"));
        yield return StartCoroutine(NormalScript("나레이션", "무사히 약을 챙겨서 나온 주인공은 오늘도 학교에 가기위해 버스를 기다리고 있다."));
        yield return StartCoroutine(NormalScript("나레이션", "이윽고 버스가 도착했고 주인공은 긴장한 모습으로 버스에 탑승한다."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공이 타는 등교 시간의 버스 안은 늘 사람이 붐빈다."));
        yield return StartCoroutine(NormalScript("주인공", "으윽....."));
        yield return StartCoroutine(NormalScript("나레이션", "오늘도 주인공은 가슴이 두근거리기 시작한다."));
        yield return StartCoroutine(NormalScript("주인공", "정신차리고 심호흡을 해보자.."));
        yield return StartCoroutine(NormalScript("주인공", "후..."));
        yield return StartCoroutine(NormalScript("나레이션", "두 번째 게임 '심호흡 게임'을 시작합니다."));
        SceneManager.LoadScene("Breathe");
    }

    
}
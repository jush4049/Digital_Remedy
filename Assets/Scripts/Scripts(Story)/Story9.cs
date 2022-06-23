using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story9 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI NameText; // 등장인물 이름 텍스트
    public TextMeshProUGUI ScriptText; // 대사 텍스트
    public string writerText = "";

    public GameObject NightRoomImage;
    public GameObject Note1;
    public GameObject Note2;
    public GameObject EndingCredit;
    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키
    bool isButtonClicked = false;

    public GameObject SaveButton;
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
        SaveButton.SetActive(false);
        EndingCredit.SetActive(false);
        Note1.SetActive(false);
        Note2.SetActive(false);
        NightRoomImage.SetActive(true);
        yield return StartCoroutine(NormalScript("나레이션", "#9 집"));
        yield return StartCoroutine(NormalScript("주인공", "그래도 무사히 집에 도착했구나"));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 차분한 마음으로 책상의자에 앉았다."));
        yield return StartCoroutine(NormalScript("주인공", "오늘 참 많은 일이 있었네.."));
        yield return StartCoroutine(NormalScript("주인공", "나를 불안하게 하는 상황들을 한번 적어보자"));
        Note1.SetActive(true);
        SaveButton.SetActive(true);
        yield return StartCoroutine(NormalScript("", ""));
        yield return StartCoroutine(NormalScript("주인공", "또.. 오늘 내가 느꼈던 불안했던 감정들도 적어보자"));
        Note1.SetActive(false);
        Note2.SetActive(true);
        yield return StartCoroutine(NormalScript("", ""));
        Note2.SetActive(false);
        SaveButton.SetActive(false);
        yield return StartCoroutine(NormalScript("주인공", "이렇게 나의 불안을 매일 기록해보니까 언제, 어디서 공황이 일어나는지 파악할 수 있네"));
        yield return StartCoroutine(NormalScript("주인공", "나 자신에 대한 통제감을 갖는데 도움이 되는 것 같아"));
        yield return StartCoroutine(NormalScript("주인공", "그리고 변화하기 위한 나의 시도가 성공했는지도 평가하게 되네"));
        yield return StartCoroutine(NormalScript("주인공", "오늘 나의 시도는 나름 성공적이었던 것 같아"));
        yield return StartCoroutine(NormalScript("주인공", "내일도 나는 잘 해낼 수 있을거야!"));
        yield return StartCoroutine(NormalScript("나레이션", "게임을 플레이 해주셔서 감사합니다!"));
        EndingCredit.SetActive(true);
        yield return StartCoroutine(NormalScript("Credit", "Produced by 건강지킴이 팀"));
        SceneManager.LoadScene("MainMenu");
    }
}
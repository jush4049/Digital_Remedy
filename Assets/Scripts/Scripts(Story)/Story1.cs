using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshPro NameText; // 등장인물 이름 텍스트
    public Text ScriptText; // 대사 텍스트
    public string writerText = "";

    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키
    bool isButtonClicked = false;

    public GameObject RoomImage;
    void Start()
    {
        StartCoroutine(StoryOn());
    }

    // Update is called once per frame
    void Update()
    {
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
        RoomImage.SetActive(true);
        yield return StartCoroutine(NormalScript("나레이션", "#1 아침 등교"));
        yield return StartCoroutine(NormalScript("주인공", "으음..."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 잠에서 깨고 아침 햇살을 받으며 침대에서 일어난다."));
        yield return StartCoroutine(NormalScript("주인공", "학교 갈 준비 하자..."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공의 하루 일과의 시작은 늘 복용하는 약을 챙기는 일이다."));
        yield return StartCoroutine(NormalScript("주인공", "맞다.. 약부터 챙겨야지"));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 현재 항우울제와 항불안제를 복용 중이다."));
        yield return StartCoroutine(NormalScript("나레이션", "방안의 책상서랍에 다가가서 비밀번호가 있는 자물쇠를 확인한다."));
        yield return StartCoroutine(NormalScript("주인공", "비밀번호가 뭐였더라?"));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 바로 옆 서랍의 비밀번호의 쪽지가 담긴 힌트를 집어든다."));
        yield return StartCoroutine(NormalScript("나레이션", "첫 번째 게임 '비밀번호 찾기 게임'를 시작합니다."));
        SceneManager.LoadScene("Chapter2");
    }
}
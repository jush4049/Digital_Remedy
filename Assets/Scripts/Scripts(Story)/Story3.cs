using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story3 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // 등장인물 이름 텍스트
    public Text ScriptText; // 대사 텍스트
    public string writerText = "";

    public GameObject SchoolRestTimeImage;
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
        SchoolRestTimeImage.SetActive(true);
        yield return StartCoroutine(NormalScript("나레이션", "#3 학교 쉬는 시간"));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 무사히 학교에 도착하였다."));
        yield return StartCoroutine(NormalScript("주인공", "다른 곳에 정신을 집중한 덕분이야.. 다행이다"));
        yield return StartCoroutine(NormalScript("친구", "안녕? 오늘 기분은 어때?"));
        yield return StartCoroutine(NormalScript("나레이션", "주인공의 친구가 다가와서 말을 건넨다."));
        yield return StartCoroutine(NormalScript("주인공", "으응.. 오늘은 그럭저럭 괜찮지만.. 오늘 수업이 걱정이야"));
        yield return StartCoroutine(NormalScript("친구", "뭐때매 그러는데?"));
        yield return StartCoroutine(NormalScript("주인공", "내가 발표하는 날이거든.. 어떡하지?"));
        yield return StartCoroutine(NormalScript("친구", "내가 선생님께 말씀드려서 양해를 구해볼까..?"));
        yield return StartCoroutine(NormalScript("주인공", "하지만... 수행평가라서 열심히 해야하는데.."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 다시 가슴이 뛰기 시작한다."));
        yield return StartCoroutine(NormalScript("나레이션", "친구는 걱정스런 표정으로 주인공을 바라보고있다."));
        yield return StartCoroutine(NormalScript("친구", "으음... 그러면 이 방법은 어때?"));
        yield return StartCoroutine(NormalScript("친구", "지금 여기서 같이 뜀뛰기라도 해보면서 안정을 취해보자!"));
        yield return StartCoroutine(NormalScript("나레이션", "세 번째 게임 '뜀뛰기 게임'을 시작합니다."));
        SceneManager.LoadScene("Chapter4");
    }
}
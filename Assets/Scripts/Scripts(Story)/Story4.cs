using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story4 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI NameText; // 등장인물 이름 텍스트
    public TextMeshProUGUI ScriptText; // 대사 텍스트
    public string writerText = "";

    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키
    bool isButtonClicked = false;

    public GameObject ClassImage;
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
        ClassImage.SetActive(true);
        yield return StartCoroutine(NormalScript("나레이션", "#4 학교 수업 시간"));
        yield return StartCoroutine(NormalScript("나레이션", "친구의 도움 덕분에 마음이 안정된 주인공은 열심히 수업을 듣는다."));
        yield return StartCoroutine(NormalScript("선생님", "자 그러면 어제 못다한 수행평가 발표를 하도록 할게요."));
        yield return StartCoroutine(NormalScript("주인공", "잘..할수 있을까"));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 긴장된 마음으로 학우들 앞에 섰다."));
        yield return StartCoroutine(NormalScript("선생님", "괜찮겠니? 힘들면 무리해서 하지 않아도 된단다."));
        yield return StartCoroutine(NormalScript("주인공", "아.. 괜찮아요 선생님 열심히 해볼게요."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 크게 호흡을 내쉰 뒤 천천히 발표를 시작했다."));
        yield return StartCoroutine(NormalScript("나레이션", "네 번째 게임 '발표 게임'을 시작합니다."));
        SceneManager.LoadScene("Sentence");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story4 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // 등장인물 이름 텍스트
    public Text ScriptText; // 대사 텍스트
    public string writerText = "";

    public GameObject ClassImage;
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
        ClassImage.SetActive(true);
        yield return StartCoroutine(NormalScript("나레이션", "#4 학교 수업 시간"));
        yield return StartCoroutine(NormalScript("나레이션", "친구의 도움 덕분에 마음이 안정된 주인공은 열심히 수업을 듣는다."));
        yield return StartCoroutine(NormalScript("선생님", "자 그러면 어제 못다한 수행평가 발표를 하도록 할게요."));
        yield return StartCoroutine(NormalScript("주인공", "잘..할수 있을까"));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 긴장된 마음으로 학우들 앞에 섰다."));
        yield return StartCoroutine(NormalScript("선생님", "괜찮겠니? 힘들면 무리해서 하지 않아도 된단다."));
        yield return StartCoroutine(NormalScript("주인공", "아.. 괜찮아요 선생님 열심히 해볼게요."));
        yield return StartCoroutine(NormalScript("주인공", "그래..여러 사람들이 도와준대로 마음을 가다듬고..."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 크게 호흡을 내쉰 뒤 천천히 발표를 시작했다."));
        yield return StartCoroutine(NormalScript("주인공", "안녕하십니까. 저는 이번 발표를 하게된..."));
        yield return StartCoroutine(NormalScript("나레이션", "잠시후,,,,"));
        yield return StartCoroutine(NormalScript("주인공", "...제 발표를 들어주셔서 감사합니다!"));
        yield return StartCoroutine(NormalScript("나레이션", "짝짝짝짝짝"));
        yield return StartCoroutine(NormalScript("나레이션", "반 친구들은 큰 환호성과 박수로 격려해주었다."));
        yield return StartCoroutine(NormalScript("친구", "잘 해냈구나...! 다행이야"));
        yield return StartCoroutine(NormalScript("주인공", "그렇구나.. 발작이 올줄 알았는데.. 꼭 일어나는 일이 아니구나"));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 오늘 겪은 일들을 머리속으로 되뇌었다."));
        yield return StartCoroutine(NormalScript("주인공", "'호흡을 가다듬고 시간을 보내면 증상들이 지나갈 수 있구나..'"));
        SceneManager.LoadScene("Chapter5");
    }
}
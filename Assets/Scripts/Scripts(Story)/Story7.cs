using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story7 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // 등장인물 이름 텍스트
    public Text ScriptText; // 대사 텍스트
    public string writerText = "";

    public GameObject AcademyImage;
    public GameObject BlackImage;
    public List<KeyCode> skipButton; // 대화를 빠르게 넘길 수 있는 키
    bool isButtonClicked = false;

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
        AcademyImage.SetActive(false);
        BlackImage.SetActive(false);
        AcademyImage.SetActive(true);
        yield return StartCoroutine(NormalScript("나레이션", "#7 학원"));
        yield return StartCoroutine(NormalScript("주인공", "다행히 별일 없이 도착했구나.."));
        yield return StartCoroutine(NormalScript("나레이션", "안도의 한숨을 내쉰 주인공은 학원에 무사히 들어간다."));
        yield return StartCoroutine(NormalScript("나레이션", "방안으로 들어서니 다른 친구가 앉아서 먼저 공부를 하고 있었다."));
        yield return StartCoroutine(NormalScript("주인공", "먼저 와있었구나.. 다가가서 인사해볼까?"));
        yield return StartCoroutine(NormalScript("주인공", "안녕?"));
        yield return StartCoroutine(NormalScript("친구2", "....."));
        BlackImage.SetActive(true);
        yield return StartCoroutine(NormalScript("주인공", "어... 왜 대답을 안하지? 내가 싫어졌나..?"));
        yield return StartCoroutine(NormalScript("주인공", "아니면...내가 뭔가 잘못한게 있나? 학교에서 뭘 잘못 말한건가...?"));
        yield return StartCoroutine(NormalScript("나레이션", "부정적인 마음이 주인공을 덮쳐온다."));
        BlackImage.SetActive(false);
        yield return StartCoroutine(NormalScript("친구2", "어? 안녕? 혹시 나한테 무슨 말 했어?"));
        yield return StartCoroutine(NormalScript("주인공", "어....? 어..."));
        yield return StartCoroutine(NormalScript("친구2", "아~ 미안미안! 나 에어팟 끼고 공부하느라 못들었어"));
        yield return StartCoroutine(NormalScript("강사", "자~ 다들 자리에 앉고 수업 시작할게요"));
        yield return StartCoroutine(NormalScript("주인공", "아!.. 내가 잘못 생각 했구나"));
        yield return StartCoroutine(NormalScript("주인공", "그래 맞아.. 천천히 생각해보면 내 생각이랑 달랐잖아"));
        yield return StartCoroutine(NormalScript("주인공", "'너무 안좋게 생각하지 말고, 상황을 극단적으로 바라보며 불안해 하지 말자..'"));
        yield return StartCoroutine(NormalScript("나레이션", "쉬는시간..."));
        yield return StartCoroutine(NormalScript("주인공", "쉬는 동안 유튜브로 편안한 소리를 들으면서 진정을 좀 해야겠어..."));
        yield return StartCoroutine(NormalScript("나레이션", "일곱 번째 게임 '청각 게임'을 시작합니다."));
        SceneManager.LoadScene("Hearing");
    }
}
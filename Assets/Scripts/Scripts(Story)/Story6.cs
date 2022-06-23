using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story6 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI NameText; // 등장인물 이름 텍스트
    public TextMeshProUGUI ScriptText; // 대사 텍스트
    public string writerText = "";

    public GameObject SchoolImage;
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
        SchoolImage.SetActive(true);
        yield return StartCoroutine(NormalScript("나레이션", "#6 하교"));
        yield return StartCoroutine(NormalScript("친구", "안녕~ 잘가"));
        yield return StartCoroutine(NormalScript("주인공", "그래 너도 잘가"));
        yield return StartCoroutine(NormalScript("나레이션", "학교 수업을 마친 주인공은 친구와 헤어지고 학원으로 가기 위해 버스 정류장으로 향한다."));
        yield return StartCoroutine(NormalScript("주인공", "으으... 또 이곳이야"));
        yield return StartCoroutine(NormalScript("나레이션", "아침에 있었던 일을 떠올린 주인공은 불안해 지기 시작한다."));
        yield return StartCoroutine(NormalScript("주인공", "안탈 수도 없는 일이고... 또 같은 일이 일어나면 어쩌지"));
        yield return StartCoroutine(NormalScript("주인공", "아니야.. 오늘 발표도 잘 했잖아. 발작이 일어나진 않을꺼야"));
        yield return StartCoroutine(NormalScript("나레이션", "용기를 낸 주인공은 스스로 이겨내 보려고 노력한다."));
        yield return StartCoroutine(NormalScript("주인공", "이럴때는 가볍게 스트레칭이라도 해봐야지.."));
        yield return StartCoroutine(NormalScript("나레이션", "여섯 번째 게임 '스트레칭 게임'을 시작합니다."));
        SceneManager.LoadScene("Stretching");
    }
}
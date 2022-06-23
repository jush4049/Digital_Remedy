using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story8_1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI NameText; // 등장인물 이름 텍스트
    public TextMeshProUGUI ScriptText; // 대사 텍스트
    public string writerText = "";

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
        yield return StartCoroutine(NormalScript("친구", "여보세요? 무슨 일이야? 학원 끝났어?"));
        yield return StartCoroutine(NormalScript("주인공", "으으.. 심장이 또 두근거려.. 어떡하지"));
        yield return StartCoroutine(NormalScript("친구", "괜찮은거야?! 내가 지금 거기로 갈까?"));
        yield return StartCoroutine(NormalScript("주인공", "괜찮아.. 이런 것쯤은.. 이겨내야지"));
        yield return StartCoroutine(NormalScript("친구", "넌 강한 녀석이야 분명 이겨낼 수 있어!"));
        yield return StartCoroutine(NormalScript("주인공", "고마워..."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 천천히 호흡을 내쉬고 가다듬으며 정신을 차리고 일어섰다."));
        yield return StartCoroutine(NormalScript("나레이션", "그리고 집으로 향했다."));
        SceneManager.LoadScene("Chapter9");
    }
}
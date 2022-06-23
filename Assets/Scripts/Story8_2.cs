using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story8_2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // 등장인물 이름 텍스트
    public Text ScriptText; // 대사 텍스트
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
        yield return StartCoroutine(NormalScript("엄마", "여보세요? 집에는 언제 들어오니?"));
        yield return StartCoroutine(NormalScript("주인공", "으으.. 심장이 또 두근거려요.. 어떡하죠"));
        yield return StartCoroutine(NormalScript("엄마", "거기 어딘데?! 어서 말해주렴 엄마가 갈께"));
        yield return StartCoroutine(NormalScript("주인공", "여기가 어디냐면..."));
        yield return StartCoroutine(NormalScript("나레이션", "곧 주인공의 엄마가 도착했고 주인공을 일으켜 세우고 안아주었다."));
        yield return StartCoroutine(NormalScript("엄마", "걱정마렴, 우리 가족들이 곁에 있으니까 괜찮을거야 이번주는 집에서 쉬지 않겠니?"));
        yield return StartCoroutine(NormalScript("주인공", "알았어요.. 고마워요 엄마.."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 엄마와 함께 집으로 향했다."));
        SceneManager.LoadScene("Chapter9");
    }
}
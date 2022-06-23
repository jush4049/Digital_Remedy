using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story8 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // 등장인물 이름 텍스트
    public Text ScriptText; // 대사 텍스트
    public string writerText = "";

    public GameObject NightStreetImage;
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
        NightStreetImage.SetActive(true);
        BlackImage.SetActive(false);
        yield return StartCoroutine(NormalScript("나레이션", "#8 하원"));
        yield return StartCoroutine(NormalScript("주인공", "오늘도 힘든 하루였어.."));
        yield return StartCoroutine(NormalScript("나레이션", "늦은 저녁 집으로 가는 아파트길, 주인공은 터벅터벅 걷고있다. "));
        yield return StartCoroutine(NormalScript("자동차", "삑삐익--!"));
        yield return StartCoroutine(NormalScript("주인공", "으아악!!"));
        yield return StartCoroutine(NormalScript("나레이션", "자동차 경적소리와 불빛에 놀란 주인공은 그만 넘어지고 말았다."));
        BlackImage.SetActive(true);
        yield return StartCoroutine(NormalScript("주인공", "허억... 허억... 심장이.."));
        yield return StartCoroutine(NormalScript("주인공", "두근거림이.. 멈추질 않아..."));
        yield return StartCoroutine(NormalScript("나레이션", "주인공은 가슴을 움켜쥔채 마음을 다잡으려고 노력한다."));
        yield return StartCoroutine(NormalScript("주인공", "괜찮을거야.. 도망치지 말자..극복해보는거야"));
        yield return StartCoroutine(NormalScript("주인공", "이건 순간적인 불안일 뿐이야.. 곧 지나갈꺼야"));
        yield return StartCoroutine(NormalScript("선택지", "도움을 요청 해볼까?"));
        SceneManager.LoadScene("PhoneNumberGame");
    }
}
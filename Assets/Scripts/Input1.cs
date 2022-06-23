using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Input1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text ResultText;
    public GameObject PhoneButton;

    public void OnPointerDown(PointerEventData pointerEventData) // 버튼을 누를 시
    {
    }
    public void OnPointerUp(PointerEventData pointerEventData) // 버튼을 눌렀다가 뗄 시
    {
        StartCoroutine(Call1());
    }

    IEnumerator Call1()
    {
        ResultText.text = "엄마에게 전화를 연결합니다...";
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Chapter8_2");
    }
}
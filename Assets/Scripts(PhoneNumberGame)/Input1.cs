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

    public void OnPointerDown(PointerEventData pointerEventData) // ��ư�� ���� ��
    {
    }
    public void OnPointerUp(PointerEventData pointerEventData) // ��ư�� �����ٰ� �� ��
    {
        StartCoroutine(Call1());
    }

    IEnumerator Call1()
    {
        ResultText.text = "�������� ��ȭ�� �����մϴ�...";
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Chapter8_2");
    }
}
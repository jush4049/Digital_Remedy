using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class Input2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text ResultText;
    public GameObject PhoneButton;

    public void OnPointerDown(PointerEventData pointerEventData) // ��ư�� ���� ��
    {
    }
    public void OnPointerUp(PointerEventData pointerEventData) // ��ư�� �����ٰ� �� ��
    {
        StartCoroutine(Call2());
    }

    IEnumerator Call2()
    {
        ResultText.text = "ģ������ ��ȭ�� �����մϴ�...";
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Chapter8_1");
    }
}
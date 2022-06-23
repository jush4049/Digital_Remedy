using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story8_2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // �����ι� �̸� �ؽ�Ʈ
    public Text ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public List<KeyCode> skipButton; // ��ȭ�� ������ �ѱ� �� �ִ� Ű
    bool isButtonClicked = false;

    void Start()
    {
        StartCoroutine(StoryOn());
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var element in skipButton) // ��ư �˻�
        {
            if (Input.GetKeyDown(element))
            {
                isButtonClicked = true;
            }
        }
    }
    public void OnPointerDown(PointerEventData pointerEventData) // ��ư�� ���� ��
    {
        isButtonClicked = true;
    }
    public void OnPointerUp(PointerEventData pointerEventData) // ��ư�� �����ٰ� �� ��
    {

    }
    // �ؽ�Ʈ Ÿ���� ���� ����
    IEnumerator NormalScript(string narrator, string narration)
    {
        NameText.text = narrator;
        writerText = "";

        writerText += narration;
        ScriptText.text = writerText;
        yield return null;

        //Ű�� �ٽ� ���� �� ���� ������ ���
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
        yield return StartCoroutine(NormalScript("����", "��������? ������ ���� ������?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "����.. ������ �� �αٰŷ���.. �����"));
        yield return StartCoroutine(NormalScript("����", "�ű� ���?! � �����ַ� ������ ����"));
        yield return StartCoroutine(NormalScript("���ΰ�", "���Ⱑ ���ĸ�..."));
        yield return StartCoroutine(NormalScript("�����̼�", "�� ���ΰ��� ������ �����߰� ���ΰ��� ������ ����� �Ⱦ��־���."));
        yield return StartCoroutine(NormalScript("����", "��������, �츮 �������� �翡 �����ϱ� �������ž� �̹��ִ� ������ ���� �ʰڴ�?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�˾Ҿ��.. �������� ����.."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ������ �Բ� ������ ���ߴ�."));
        SceneManager.LoadScene("Chapter9");
    }
}
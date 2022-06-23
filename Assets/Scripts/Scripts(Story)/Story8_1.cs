using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story8_1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI NameText; // �����ι� �̸� �ؽ�Ʈ
    public TextMeshProUGUI ScriptText; // ��� �ؽ�Ʈ
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
        yield return StartCoroutine(NormalScript("ģ��", "��������? ���� ���̾�? �п� ������?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "����.. ������ �� �αٰŷ�.. �����"));
        yield return StartCoroutine(NormalScript("ģ��", "�������ž�?! ���� ���� �ű�� ����?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "������.. �̷� ������.. �̰ܳ�����"));
        yield return StartCoroutine(NormalScript("ģ��", "�� ���� �༮�̾� �и� �̰ܳ� �� �־�!"));
        yield return StartCoroutine(NormalScript("���ΰ�", "����..."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� õõ�� ȣ���� ������ ���ٵ����� ������ ������ �Ͼ��."));
        yield return StartCoroutine(NormalScript("�����̼�", "�׸��� ������ ���ߴ�."));
        SceneManager.LoadScene("Chapter9");
    }
}
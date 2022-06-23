using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story3 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // �����ι� �̸� �ؽ�Ʈ
    public Text ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public GameObject SchoolRestTimeImage;
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
        SchoolRestTimeImage.SetActive(true);
        yield return StartCoroutine(NormalScript("�����̼�", "#3 �б� ���� �ð�"));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ������ �б��� �����Ͽ���."));
        yield return StartCoroutine(NormalScript("���ΰ�", "�ٸ� ���� ������ ������ �����̾�.. �����̴�"));
        yield return StartCoroutine(NormalScript("ģ��", "�ȳ�? ���� ����� �?"));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ģ���� �ٰ��ͼ� ���� �ǳٴ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "����.. ������ �׷����� ��������.. ���� ������ �����̾�"));
        yield return StartCoroutine(NormalScript("ģ��", "������ �׷��µ�?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "���� ��ǥ�ϴ� ���̰ŵ�.. �����?"));
        yield return StartCoroutine(NormalScript("ģ��", "���� �����Բ� ��������� ���ظ� ���غ���..?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "������... �����򰡶� ������ �ؾ��ϴµ�.."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� �ٽ� ������ �ٱ� �����Ѵ�."));
        yield return StartCoroutine(NormalScript("�����̼�", "ģ���� �������� ǥ������ ���ΰ��� �ٶ󺸰��ִ�."));
        yield return StartCoroutine(NormalScript("ģ��", "����... �׷��� �� ����� �?"));
        yield return StartCoroutine(NormalScript("ģ��", "���� ���⼭ ���� �ܶٱ�� �غ��鼭 ������ ���غ���!"));
        yield return StartCoroutine(NormalScript("�����̼�", "�� ��° ���� '�ܶٱ� ����'�� �����մϴ�."));
        SceneManager.LoadScene("Chapter4");
    }
}
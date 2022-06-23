using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story4 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI NameText; // �����ι� �̸� �ؽ�Ʈ
    public TextMeshProUGUI ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public List<KeyCode> skipButton; // ��ȭ�� ������ �ѱ� �� �ִ� Ű
    bool isButtonClicked = false;

    public GameObject ClassImage;
    void Start()
    {
        StartCoroutine(StoryOn());
    }

    // Update is called once per frame
    void Update()
    {
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
        ClassImage.SetActive(true);
        yield return StartCoroutine(NormalScript("�����̼�", "#4 �б� ���� �ð�"));
        yield return StartCoroutine(NormalScript("�����̼�", "ģ���� ���� ���п� ������ ������ ���ΰ��� ������ ������ ��´�."));
        yield return StartCoroutine(NormalScript("������", "�� �׷��� ���� ������ ������ ��ǥ�� �ϵ��� �ҰԿ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "��..�Ҽ� ������"));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ����� �������� �п�� �տ� ����."));
        yield return StartCoroutine(NormalScript("������", "�����ڴ�? ����� �����ؼ� ���� �ʾƵ� �ȴܴ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "��.. �����ƿ� ������ ������ �غ��Կ�."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ũ�� ȣ���� ���� �� õõ�� ��ǥ�� �����ߴ�."));
        yield return StartCoroutine(NormalScript("�����̼�", "�� ��° ���� '��ǥ ����'�� �����մϴ�."));
        SceneManager.LoadScene("Sentence");
    }
}
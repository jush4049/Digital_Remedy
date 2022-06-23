using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshPro NameText; // �����ι� �̸� �ؽ�Ʈ
    public Text ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public List<KeyCode> skipButton; // ��ȭ�� ������ �ѱ� �� �ִ� Ű
    bool isButtonClicked = false;

    public GameObject RoomImage;
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
        RoomImage.SetActive(true);
        yield return StartCoroutine(NormalScript("�����̼�", "#1 ��ħ �"));
        yield return StartCoroutine(NormalScript("���ΰ�", "����..."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� �ῡ�� ���� ��ħ �޻��� ������ ħ�뿡�� �Ͼ��."));
        yield return StartCoroutine(NormalScript("���ΰ�", "�б� �� �غ� ����..."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� �Ϸ� �ϰ��� ������ �� �����ϴ� ���� ì��� ���̴�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "�´�.. ����� ì�ܾ���"));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ���� �׿������ �׺Ҿ����� ���� ���̴�."));
        yield return StartCoroutine(NormalScript("�����̼�", "����� å�󼭶��� �ٰ����� ��й�ȣ�� �ִ� �ڹ��踦 Ȯ���Ѵ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "��й�ȣ�� ��������?"));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� �ٷ� �� ������ ��й�ȣ�� ������ ��� ��Ʈ�� ������."));
        yield return StartCoroutine(NormalScript("�����̼�", "ù ��° ���� '��й�ȣ ã�� ����'�� �����մϴ�."));
        SceneManager.LoadScene("Chapter2");
    }
}
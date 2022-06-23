using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story6 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI NameText; // �����ι� �̸� �ؽ�Ʈ
    public TextMeshProUGUI ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public GameObject SchoolImage;
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
        SchoolImage.SetActive(true);
        yield return StartCoroutine(NormalScript("�����̼�", "#6 �ϱ�"));
        yield return StartCoroutine(NormalScript("ģ��", "�ȳ�~ �߰�"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�׷� �ʵ� �߰�"));
        yield return StartCoroutine(NormalScript("�����̼�", "�б� ������ ��ģ ���ΰ��� ģ���� ������� �п����� ���� ���� ���� ���������� ���Ѵ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "����... �� �̰��̾�"));
        yield return StartCoroutine(NormalScript("�����̼�", "��ħ�� �־��� ���� ���ø� ���ΰ��� �Ҿ��� ���� �����Ѵ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "��Ż ���� ���� ���̰�... �� ���� ���� �Ͼ�� ��¼��"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�ƴϾ�.. ���� ��ǥ�� �� ���ݾ�. ������ �Ͼ�� ��������"));
        yield return StartCoroutine(NormalScript("�����̼�", "��⸦ �� ���ΰ��� ������ �̰ܳ� ������ ����Ѵ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "�̷����� ������ ��Ʈ��Ī�̶� �غ�����.."));
        yield return StartCoroutine(NormalScript("�����̼�", "���� ��° ���� '��Ʈ��Ī ����'�� �����մϴ�."));
        SceneManager.LoadScene("Stretching");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story2 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // �����ι� �̸� �ؽ�Ʈ
    public Text ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public GameObject InBusImage;
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
        InBusImage.SetActive(false);
        InBusImage.SetActive(true);
        yield return StartCoroutine(NormalScript("�����̼�", "#2 ���� ������"));
        yield return StartCoroutine(NormalScript("�����̼�", "������ ���� ì�ܼ� ���� ���ΰ��� ���õ� �б��� �������� ������ ��ٸ��� �ִ�."));
        yield return StartCoroutine(NormalScript("�����̼�", "������ ������ �����߰� ���ΰ��� ������ ������� ������ ž���Ѵ�."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� Ÿ�� � �ð��� ���� ���� �� ����� �պ��."));
        yield return StartCoroutine(NormalScript("���ΰ�", "����....."));
        yield return StartCoroutine(NormalScript("�����̼�", "���õ� ���ΰ��� ������ �αٰŸ��� �����Ѵ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "���õ� �Ȱ���.."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ������ ����� ��Ȳ���� ���� ����� �Ѵ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "������ �����غ���.. ���� �������� �ƴϾ�.."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ���� �������� ��ü 3������ ���÷������ �Ѵ�."));
        yield return StartCoroutine(NormalScript("�����̼�", "�� ��° ���� '�ð� ����'�� �����մϴ�."));
        SceneManager.LoadScene("Chapter3");
    }

    
}
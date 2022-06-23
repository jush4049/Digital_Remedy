using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story9 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // �����ι� �̸� �ؽ�Ʈ
    public Text ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public GameObject NightRoomImage;
    public GameObject Note1;
    public GameObject Note2;
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
        Note1.SetActive(false);
        Note2.SetActive(false);
        NightRoomImage.SetActive(true);
        yield return StartCoroutine(NormalScript("�����̼�", "#9 ��"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�׷��� ������ ���� �����߱���"));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ������ �������� å�����ڿ� �ɾҴ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "���� �� ���� ���� �־���.."));
        yield return StartCoroutine(NormalScript("���ΰ�", "���� �Ҿ��ϰ� �ϴ� ��Ȳ���� �ѹ� �����"));
        Note1.SetActive(true);
        yield return StartCoroutine(NormalScript("", ""));
        yield return StartCoroutine(NormalScript("���ΰ�", "��.. ���� ���� ������ �Ҿ��ߴ� �����鵵 �����"));
        Note1.SetActive(false);
        Note2.SetActive(true);
        yield return StartCoroutine(NormalScript("", ""));
        Note2.SetActive(false);
        yield return StartCoroutine(NormalScript("���ΰ�", "�̷��� ���� �Ҿ��� ���� ����غ��ϱ� ����, ��� ��Ȳ�� �Ͼ���� �ľ��� �� �ֳ�"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�� �ڽſ� ���� �������� ���µ� ������ �Ǵ� �� ����"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�׸��� ��ȭ�ϱ� ���� ���� �õ��� �����ߴ����� ���ϰ� �ǳ�"));
        yield return StartCoroutine(NormalScript("���ΰ�", "���� ���� �õ��� ���� �������̾��� �� ����"));
        yield return StartCoroutine(NormalScript("���ΰ�", "���ϵ� ���� �� �س� �� �����ž�!"));
        yield return StartCoroutine(NormalScript("�����̼�", "������ �÷��� ���ּż� �����մϴ�!"));
        SceneManager.LoadScene("MainMenu");
    }
}
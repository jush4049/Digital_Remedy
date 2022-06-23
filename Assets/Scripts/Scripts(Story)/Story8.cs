using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story8 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // �����ι� �̸� �ؽ�Ʈ
    public Text ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public GameObject NightStreetImage;
    public GameObject BlackImage;
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
        NightStreetImage.SetActive(true);
        BlackImage.SetActive(false);
        yield return StartCoroutine(NormalScript("�����̼�", "#8 �Ͽ�"));
        yield return StartCoroutine(NormalScript("���ΰ�", "���õ� ���� �Ϸ翴��.."));
        yield return StartCoroutine(NormalScript("�����̼�", "���� ���� ������ ���� ����Ʈ��, ���ΰ��� �͹��͹� �Ȱ��ִ�. "));
        yield return StartCoroutine(NormalScript("�ڵ���", "�����--!"));
        yield return StartCoroutine(NormalScript("���ΰ�", "���ƾ�!!"));
        yield return StartCoroutine(NormalScript("�����̼�", "�ڵ��� �����Ҹ��� �Һ��� ��� ���ΰ��� �׸� �Ѿ����� ���Ҵ�."));
        BlackImage.SetActive(true);
        yield return StartCoroutine(NormalScript("���ΰ�", "���... ���... ������.."));
        yield return StartCoroutine(NormalScript("���ΰ�", "�αٰŸ���.. ������ �ʾ�..."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ������ ������ä ������ ���������� ����Ѵ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "�������ž�.. ����ġ�� ����..�غ��غ��°ž�"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�̰� �������� �Ҿ��� ���̾�.. �� ����������"));
        yield return StartCoroutine(NormalScript("������", "������ ��û �غ���?"));
        SceneManager.LoadScene("PhoneNumberGame");
    }
}
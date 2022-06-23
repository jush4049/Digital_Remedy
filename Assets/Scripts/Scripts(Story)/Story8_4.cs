using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story8_4 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
        yield return StartCoroutine(NormalScript("û�ҳ���ȭ", "�� �ȳ��ϼ���. 24�ð� û�ҳ���ȭ�Դϴ�. ������ ���͵帱���?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "����.. ������ �� �αٰŷ���.. �����"));
        yield return StartCoroutine(NormalScript("û�ҳ���ȭ", "�л��� �켱 �����Ͻð� �ڼ��� ������ �˷��ֽǼ� �����Ű���?"));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ������ ���� ���� �����Ǿ��� ������ ������ ���ư���."));
        SceneManager.LoadScene("Chapter9");
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story4 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // �����ι� �̸� �ؽ�Ʈ
    public Text ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public GameObject ClassImage;
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
        ClassImage.SetActive(true);
        yield return StartCoroutine(NormalScript("�����̼�", "#4 �б� ���� �ð�"));
        yield return StartCoroutine(NormalScript("�����̼�", "ģ���� ���� ���п� ������ ������ ���ΰ��� ������ ������ ��´�."));
        yield return StartCoroutine(NormalScript("������", "�� �׷��� ���� ������ ������ ��ǥ�� �ϵ��� �ҰԿ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "��..�Ҽ� ������"));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ����� �������� �п�� �տ� ����."));
        yield return StartCoroutine(NormalScript("������", "�����ڴ�? ����� �����ؼ� ���� �ʾƵ� �ȴܴ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "��.. �����ƿ� ������ ������ �غ��Կ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "�׷�..���� ������� �����ش�� ������ ���ٵ��..."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ũ�� ȣ���� ���� �� õõ�� ��ǥ�� �����ߴ�."));
        yield return StartCoroutine(NormalScript("���ΰ�", "�ȳ��Ͻʴϱ�. ���� �̹� ��ǥ�� �ϰԵ�..."));
        yield return StartCoroutine(NormalScript("�����̼�", "�����,,,,"));
        yield return StartCoroutine(NormalScript("���ΰ�", "...�� ��ǥ�� ����ּż� �����մϴ�!"));
        yield return StartCoroutine(NormalScript("�����̼�", "¦¦¦¦¦"));
        yield return StartCoroutine(NormalScript("�����̼�", "�� ģ������ ū ȯȣ���� �ڼ��� �ݷ����־���."));
        yield return StartCoroutine(NormalScript("ģ��", "�� �س±���...! �����̾�"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�׷�����.. ������ ���� �˾Ҵµ�.. �� �Ͼ�� ���� �ƴϱ���"));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ���� ���� �ϵ��� �Ӹ������� �ǳ�����."));
        yield return StartCoroutine(NormalScript("���ΰ�", "'ȣ���� ���ٵ�� �ð��� ������ ������� ������ �� �ֱ���..'"));
        SceneManager.LoadScene("Chapter5");
    }
}
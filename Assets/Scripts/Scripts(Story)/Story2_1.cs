using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Story2_1 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public TextMeshProUGUI NameText; // �����ι� �̸� �ؽ�Ʈ
    public TextMeshProUGUI ScriptText; // ��� �ؽ�Ʈ
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
        InBusImage.SetActive(true);
        yield return StartCoroutine(NormalScript("���ΰ�", "�Ŀ�......��.."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ������ ������ �����Ǿ� ���� �ִ�."));
        yield return StartCoroutine(NormalScript("�����̼�", "������ ������ �ֺ��� ������ ������ �־���."));
        yield return StartCoroutine(NormalScript("���ΰ�", "����... �ȵǰھ� �� ��Ȳ���� ����ߵ�.."));
        yield return StartCoroutine(NormalScript("�����̼�", "���ΰ��� ���� ���� ���� �������� ��ü 3������ ����غ���."));
        yield return StartCoroutine(NormalScript("�����̼�", "�̾ '�ð� ����'�� �����մϴ�."));
        SceneManager.LoadScene("Sight");
    }

    
}
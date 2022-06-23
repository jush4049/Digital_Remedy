using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story5 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // �����ι� �̸� �ؽ�Ʈ
    public Text ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public GameObject SchoolRestaurantImage;
    public GameObject FoodImage;
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
        FoodImage.SetActive(false);
        SchoolRestaurantImage.SetActive(true);
        yield return StartCoroutine(NormalScript("�����̼�", "#5 �б� ���� �ð�"));
        yield return StartCoroutine(NormalScript("�����̼�", "��ǥ�� ������ ��ģ ���ΰ��� �� ���� �Ļ��� �� �־���."));
        FoodImage.SetActive(true);
        yield return StartCoroutine(NormalScript("ģ��", "���� �� ���־���~! ��ǥ ���ϴ���"));
        yield return StartCoroutine(NormalScript("���ΰ�", "���� ����.."));
        FoodImage.SetActive(false);
        yield return StartCoroutine(NormalScript("�����̼�", "��̰� ������ ���� �� ���ΰ��� ��ħ�� ì�ܿ� ���� ������."));
        yield return StartCoroutine(NormalScript("ģ��", "�ٵ� �� �� ���ݾ�, �������� �Ծ�� �ϴ°ž�?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "����..? �׷��� �� ���������� �Ծ�� ���� ������.."));
        yield return StartCoroutine(NormalScript("ģ��", "������ �ʹ� �࿡�� �����ϴ� �͵� ���� �ʴٰ� ����ŵ�.."));
        yield return StartCoroutine(NormalScript("ģ��", "�� �̷��� ���̵� ����� �̰ܳ� �� �����ž�~ ����"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�׷���..?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "���ΰ��� ���� �����ϸ� �������� ������ ����."));
        yield return StartCoroutine(NormalScript("�����̼�", "�ټ� ��° ���� '�� �Ա� ����'�� �����մϴ�."));
        SceneManager.LoadScene("TakeMedicineGame");
    }
}
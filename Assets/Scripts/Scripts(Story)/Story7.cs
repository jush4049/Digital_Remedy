using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Story7 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text NameText; // �����ι� �̸� �ؽ�Ʈ
    public Text ScriptText; // ��� �ؽ�Ʈ
    public string writerText = "";

    public GameObject AcademyImage;
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
        AcademyImage.SetActive(false);
        BlackImage.SetActive(false);
        AcademyImage.SetActive(true);
        yield return StartCoroutine(NormalScript("�����̼�", "#7 �п�"));
        yield return StartCoroutine(NormalScript("���ΰ�", "������ ���� ���� �����߱���.."));
        yield return StartCoroutine(NormalScript("�����̼�", "�ȵ��� �Ѽ��� ���� ���ΰ��� �п��� ������ ����."));
        yield return StartCoroutine(NormalScript("�����̼�", "������� ���� �ٸ� ģ���� �ɾƼ� ���� ���θ� �ϰ� �־���."));
        yield return StartCoroutine(NormalScript("���ΰ�", "���� ���־�����.. �ٰ����� �λ��غ���?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�ȳ�?"));
        yield return StartCoroutine(NormalScript("ģ��2", "....."));
        BlackImage.SetActive(true);
        yield return StartCoroutine(NormalScript("���ΰ�", "��... �� ����� ������? ���� �Ⱦ�����..?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�ƴϸ�...���� ���� �߸��Ѱ� �ֳ�? �б����� �� �߸� ���Ѱǰ�...?"));
        yield return StartCoroutine(NormalScript("�����̼�", "�������� ������ ���ΰ��� ���Ŀ´�."));
        BlackImage.SetActive(false);
        yield return StartCoroutine(NormalScript("ģ��2", "��? �ȳ�? Ȥ�� ������ ���� �� �߾�?"));
        yield return StartCoroutine(NormalScript("���ΰ�", "��....? ��..."));
        yield return StartCoroutine(NormalScript("ģ��2", "��~ �̾ȹ̾�! �� ������ ���� �����ϴ��� �������"));
        yield return StartCoroutine(NormalScript("����", "��~ �ٵ� �ڸ��� �ɰ� ���� �����ҰԿ�"));
        yield return StartCoroutine(NormalScript("���ΰ�", "��!.. ���� �߸� ���� �߱���"));
        yield return StartCoroutine(NormalScript("���ΰ�", "�׷� �¾�.. õõ�� �����غ��� �� �����̶� �޶��ݾ�"));
        yield return StartCoroutine(NormalScript("���ΰ�", "'�ʹ� ������ �������� ����, ��Ȳ�� �ش������� �ٶ󺸸� �Ҿ��� ���� ����..'"));
        yield return StartCoroutine(NormalScript("�����̼�", "���½ð�..."));
        yield return StartCoroutine(NormalScript("���ΰ�", "���� ���� ��Ʃ��� ����� �Ҹ��� �����鼭 ������ �� �ؾ߰ھ�..."));
        yield return StartCoroutine(NormalScript("�����̼�", "�ϰ� ��° ���� 'û�� ����'�� �����մϴ�."));
        SceneManager.LoadScene("Hearing");
    }
}
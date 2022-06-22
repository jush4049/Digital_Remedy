using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText; // Ÿ�̸� �ؽ�Ʈ
    public GameObject AttentionText; // "�鸮�� �Ҹ��� �������ּ���.."
    public GameObject Answer; // ���� ȭ��
    // ��ü ���� �ð��� ����
    float SetTime = 10;

    // �д����� �ʴ����� ����� ����
    int min;
    float sec;

    AudioSource audioSource;
    public AudioClip Stage1Sound;

    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(Stage1Sound);
    }

    void Update()
    {
        // ���� �ð� ����
        SetTime -= Time.deltaTime;

        // ��ü �ð��� 60�� ���� Ŭ ��
        if (SetTime >= 60f)
        {
            // 60���� ������ ����� ���� �д����� ����
            min = (int)SetTime / 60;
            // 60���� ������ ����� �������� �ʴ����� ����
            sec = SetTime % 60;
            // UI�� ǥ�����ش�
            TimerText.text = "���� �ð� : " + min + "��" + (int)sec + "��";
        }

        // ��ü�ð��� 60�� �̸��� ��
        if (SetTime < 60f)
        {
            // �� ������ �ʿ�������Ƿ� �ʴ����� ������ ����
            TimerText.text = "���� �ð� : " + (int)SetTime + "��";
        }

        // ���� �ð��� 0���� �۾��� ��
        if (SetTime <= 0)
        {
            // UI �ؽ�Ʈ�� 0�ʷ� ������Ŵ.
            TimerText.text = "���� �ð� : 0��";
            audioSource.Pause();
            AttentionText.SetActive(false);
            Answer.SetActive(true);
        }
    }
}

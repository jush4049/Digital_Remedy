using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LockManager : MonoBehaviour
{
    public AudioSource unlockSound;
    public GameObject wrongAnswerTextObject;


    [Tooltip("100>10>1 �̷��� �����ڸ����� �����ڸ������� �־�� ��")]
    public TextMeshProUGUI[] lockTexts;
    [Tooltip("000�ϰ�� 0���� �Է��ϼ���")]
    public int answer;
    public int userAnswer;
    
    public void SubmitAnswer()
    {
        loadNumber();

        checkCurrectAnswer();
    }

    private void loadNumber()
    {
        userAnswer = 0;
        for (int i=0; i<lockTexts.Length; i++)
        {
            userAnswer += int.Parse(lockTexts[i].text) * (int)Mathf.Pow(10, lockTexts.Length - i - 1);
        }
    }

    private void checkCurrectAnswer()
    {
        if (answer == userAnswer) // �����϶� ó��
            unlockSound.Play();
        else // �����϶� ó��
            wrongAnswerTextObject.SetActive(true);
    }
}

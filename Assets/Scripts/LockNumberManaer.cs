using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockNumberManaer : MonoBehaviour
{
    private int currentNumber; // ���� �ڹ��迡 �����Ǿ��ִ� ����

    public void Increase(TextMeshProUGUI text)
    {
        getTextToStr(text.text);

        if(currentNumber < 9)
        {
            currentNumber++;
        }
        else
        {
            currentNumber = 0;
        }

        text.SetText(currentNumber.ToString());
    }

    public void Decrease(TextMeshProUGUI text)
    {
        getTextToStr(text.text);

        if (currentNumber > 0)
        {
            currentNumber--;
        }
        else
        {
            currentNumber = 9;
        }

        text.SetText(currentNumber.ToString());
    }

    // Text���� �о�� int�� ����
    private void getTextToStr(string text)
    {
        currentNumber = int.Parse(text);
    }

}

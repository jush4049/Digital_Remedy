using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LockNumberManaer : MonoBehaviour
{
    private int currentNumber; // 현재 자물쇠에 설정되어있는 숫자

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

    // Text값을 읽어와 int로 저장
    private void getTextToStr(string text)
    {
        currentNumber = int.Parse(text);
    }

}

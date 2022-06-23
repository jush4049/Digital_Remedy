using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RunManager : MonoBehaviour
{
    [SerializeField]
    private Pedometer pedometer;    // ������
    [SerializeField]
    private Animator humanAnimator; // ĳ���� �ִϸ�����

    [SerializeField]
    private Slider slider;  // ���� ���� ���� ��������
    [SerializeField]
    private TextMeshProUGUI instructionText;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("Run");
    }

    // Update is called once per frame
    void Update()
    {
        if (pedometer.isWalking || pedometer.isJumping)     // �����̰� ������ �ȱ� �ִϸ��̼�
            humanAnimator.SetBool("isRun", true);
        else    // �������� �ʰ� ������ ������ ���� �ִϸ��̼�
            humanAnimator.SetBool("isRun", false);

        switch (pedometer.steps)
        {
            case 50:
                instructionText.text = "���� �� ���Ҿ��!";
                break;
            case 100:
                instructionText.text = "�����ϼ̽��ϴ�!";
                break;
            default:
                break;
        }
        if (pedometer.steps < 100)
            slider.value = pedometer.steps / 100f;
    }
    IEnumerator Run()
    {
        float fill = 0;
        while (true)
        {
            fill++;
            slider.value = fill / 100;
            Debug.Log("slider.value = "+ slider.value);
            yield return new WaitForSeconds(0.1f);
        }
    }
}

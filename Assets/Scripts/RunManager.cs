using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    [SerializeField]
    private Pedometer pedometer;    // ������
    [SerializeField]
    private Animator humanAnimator; // ĳ���� �ִϸ�����

    [SerializeField]
    private TextMeshProUGUI instructionText;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RunManager : MonoBehaviour
{
    [SerializeField]
    private Pedometer pedometer;    // 만보기
    [SerializeField]
    private Animator humanAnimator; // 캐릭터 애니메이터

    [SerializeField]
    private TextMeshProUGUI instructionText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pedometer.isWalking || pedometer.isJumping)     // 움직이고 있으면 걷기 애니메이션
            humanAnimator.SetBool("isRun", true);
        else    // 움직이지 않고 있으면 가만히 서기 애니메이션
            humanAnimator.SetBool("isRun", false);

        switch (pedometer.steps)
        {
            case 50:
                instructionText.text = "이제 반 남았어요!";
                break;
            case 100:
                instructionText.text = "수고하셨습니다!";
                break;
            default:
                break;
        }
    }
}

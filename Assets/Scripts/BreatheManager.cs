using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BreatheManager : MonoBehaviour
{
    [SerializeField]
    private Animator circleAnimator;
    [SerializeField]
    private TextMeshProUGUI instructionText;

    private Dictionary<string, int> instructions;
    private int currentTime = 0;
    private const int expandTime = 2;
    private const int largeTime = 9;
    private const int dwindleTime = 11;
    private const int idleTime = 13;

    public GameObject GoSceneButton;
    // Start is called before the first frame update
    void Start()
    {
        GoSceneButton.SetActive(false);
        instructions = new Dictionary<string, int>() 
        { 
            { "한 손을 갈비뼈 바로 아래 복부에 얹어 보세요", 2 },
            { "코로 숨을 들이마셔요", 2 },
            { "폐 안쪽까지 깊고 천천히 공기를 최대한 아래로 내려보내요", 3 },
            { "손을 얹은 부위가 부풀어야 합니다", 2 },
            { "숨을 잠시 짧게 멈춰요", 2 },
            { "코나 입으로 숨을 천천히 내뱉어요", 2 },
    };
        StartCoroutine("StartBreatheCoroutine");
    }
    public void GoScene()
    {
        SceneManager.LoadScene("Chapter2_1");
    }
    IEnumerator StartBreatheCoroutine()
    {
        string instruction;
        int time;
        foreach (KeyValuePair<string, int> item in instructions)
        {
            switch (currentTime)
            {
                case expandTime:
                    circleAnimator.SetTrigger("expand");
                    break;
                case largeTime:
                    circleAnimator.SetTrigger("large");
                    break;
                case dwindleTime:
                    circleAnimator.SetTrigger("dwindle");
                    break;
                case idleTime:
                    circleAnimator.SetTrigger("idle");
                    break;
                default:
                    break;
            }
            instruction = item.Key;
            time = item.Value;

            currentTime += time;    // 시간 업데이트
            instructionText.text = instruction; // 지시문 변경

            yield return new WaitForSeconds(time);

            GoSceneButton.SetActive(true);
        }
    }
}

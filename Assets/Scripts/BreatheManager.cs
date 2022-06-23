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
            { "�� ���� ����� �ٷ� �Ʒ� ���ο� ��� ������", 2 },
            { "�ڷ� ���� ���̸��ſ�", 2 },
            { "�� ���ʱ��� ��� õõ�� ���⸦ �ִ��� �Ʒ��� ����������", 3 },
            { "���� ���� ������ ��Ǯ��� �մϴ�", 2 },
            { "���� ��� ª�� �����", 2 },
            { "�ڳ� ������ ���� õõ�� ������", 2 },
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

            currentTime += time;    // �ð� ������Ʈ
            instructionText.text = instruction; // ���ù� ����

            yield return new WaitForSeconds(time);

            GoSceneButton.SetActive(true);
        }
    }
}

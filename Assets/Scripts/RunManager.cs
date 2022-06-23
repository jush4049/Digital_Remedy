using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RunManager : MonoBehaviour
{
    [SerializeField]
    private Pedometer pedometer;    // 만보기
    [SerializeField]
    private Animator humanAnimator; // 캐릭터 애니메이터

    [SerializeField]
    private Slider slider;  // 걸음 수에 따른 게이지바
    [SerializeField]
    private TextMeshProUGUI instructionText;

    public GameObject GoSceneButton;
    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadScene("Chapter4");
        //StartCoroutine("Run");
        GoSceneButton.SetActive(false);
    }

    public void GoScene()
    {
        SceneManager.LoadScene("Chapter4");
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
                GoSceneButton.SetActive(true);
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

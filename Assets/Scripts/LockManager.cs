using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LockManager : MonoBehaviour
{
    public AudioSource unlockSound;
    public GameObject wrongAnswerTextObject;
    public GameObject currectAnswerObject;

    public GameObject GoSceneButton;

    [Tooltip("100>10>1 이렇게 높은자리부터 낮은자리순으로 넣어야 함")]
    public TextMeshProUGUI[] lockTexts;
    [Tooltip("000일경우 0으로 입력하세요")]
    public int answer;
    public int userAnswer;
    
    void Start()
    {
        GoSceneButton.SetActive(false);
    }
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
    public void GoScene()
    {
        SceneManager.LoadScene("Chapter2");
    }
    private void checkCurrectAnswer()
    {
        if (answer == userAnswer) // 정답일때 처리
        {
            unlockSound.Play();
            currectAnswerObject.SetActive(true);
            GoSceneButton.SetActive(true);
        }    
        else // 오답일때 처리
            wrongAnswerTextObject.SetActive(true);
    }
}

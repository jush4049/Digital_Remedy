using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text TimerText; // 타이머 텍스트
    public GameObject AttentionText; // "들리는 소리에 집중해주세요.."
    public GameObject Answer; // 정답 화면
    // 전체 제한 시간을 설정
    float SetTime = 10;

    // 분단위와 초단위를 담당할 변수
    int min;
    float sec;

    AudioSource audioSource;
    public AudioClip Stage1Sound;

    private void Awake()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(Stage1Sound);
    }

    void Update()
    {
        // 남은 시간 감소
        SetTime -= Time.deltaTime;

        // 전체 시간이 60초 보다 클 때
        if (SetTime >= 60f)
        {
            // 60으로 나눠서 생기는 몫을 분단위로 변경
            min = (int)SetTime / 60;
            // 60으로 나눠서 생기는 나머지를 초단위로 설정
            sec = SetTime % 60;
            // UI를 표현해준다
            TimerText.text = "남은 시간 : " + min + "분" + (int)sec + "초";
        }

        // 전체시간이 60초 미만일 때
        if (SetTime < 60f)
        {
            // 분 단위는 필요없어지므로 초단위만 남도록 설정
            TimerText.text = "남은 시간 : " + (int)SetTime + "초";
        }

        // 남은 시간이 0보다 작아질 때
        if (SetTime <= 0)
        {
            // UI 텍스트를 0초로 고정시킴.
            TimerText.text = "남은 시간 : 0초";
            audioSource.Pause();
            AttentionText.SetActive(false);
            Answer.SetActive(true);
        }
    }
}

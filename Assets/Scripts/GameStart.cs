using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public Text InfoText;
    public GameObject TimerText;
    public GameObject PictureAndSound;
    public GameObject Answer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameReady());
        TimerText.SetActive(false);
        PictureAndSound.SetActive(false);
        Answer.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public IEnumerator GameReady()
    {
        InfoText.text = "3";
        yield return new WaitForSeconds(1.0f);
        InfoText.text = "2";
        yield return new WaitForSeconds(1.0f);
        InfoText.text = "1";
        yield return new WaitForSeconds(1.0f);
        InfoText.text = "Ω√¿€!";
        yield return new WaitForSeconds(0.5f);
        InfoText.text = "";
        TimerText.SetActive(true);
        PictureAndSound.SetActive(true);
    }
}

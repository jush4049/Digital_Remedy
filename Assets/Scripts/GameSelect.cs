using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClickStory()
    {
        Debug.Log("스토리 모드 클릭");
    }

    public void ClickSight()
    {
        Debug.Log("시각 게임 클릭");
        SceneManager.LoadScene("Sight");
    }

    public void ClickHearing()
    {
        Debug.Log("청각 게임 클릭");
        SceneManager.LoadScene("Hearing");
    }
}

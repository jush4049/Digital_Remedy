using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject settingUI; // 설정UI 오브젝트

    public void ClickEmergencyStart()
    {
        Debug.Log("[LoadScene]EmergencyStart");
    }

    public void ClickStart()
    {
        SceneManager.LoadScene("GameSelect");
        Debug.Log("[LoadScene]GameSelect");
    }

    public void ClickSetting()
    {
        settingUI.SetActive(true);
    }

    public void ClickExitSetting()
    {
        settingUI.SetActive(false);
    }
}

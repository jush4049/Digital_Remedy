using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public ToggleButtonManager toggleButtonManager;

    public void ClickEmergencyStart()
    {
        string selectedGameName = toggleButtonManager.GetSelectedGameString();

        if(selectedGameName != "")
            SceneManager.LoadScene(selectedGameName);
    }

    public void ClickStart()
    {
        SceneManager.LoadScene("GameSelect");
        Debug.Log("[LoadScene]GameSelect");
    }

    public void ClickSetting()
    {
        animator.SetBool("Appear", true);
    }

    public void ClickExitSetting()
    {
        animator.SetBool("Appear", false);
    }
}

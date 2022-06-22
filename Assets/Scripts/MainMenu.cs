using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        SceneManager.LoadScene("Setting");
        Debug.Log("[LoadScene]Setting");
    }
}

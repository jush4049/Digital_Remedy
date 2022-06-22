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

    public void ClickSight()
    {
        SceneManager.LoadScene("Sight");
        Debug.Log("[LoadScene]Sight");
    }

    public void ClickHearing()
    {
        SceneManager.LoadScene("Hearing");
        Debug.Log("[LoadScene]Hearing");
    }

    public void ClickBreathing()
    {
        SceneManager.LoadScene("Hearing");
        Debug.Log("[LoadScene]Hearing");
    }
}

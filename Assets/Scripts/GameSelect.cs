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
        Debug.Log("���丮 ��� Ŭ��");
    }

    public void ClickSight()
    {
        Debug.Log("�ð� ���� Ŭ��");
        SceneManager.LoadScene("Sight");
    }

    public void ClickHearing()
    {
        Debug.Log("û�� ���� Ŭ��");
        SceneManager.LoadScene("Hearing");
    }
}

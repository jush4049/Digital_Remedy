using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NoteSave : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public InputField inputNote1;
    public InputField inputNote2;
    public GameObject SaveInfoText;
    void Start()
    {
        SaveInfoText.SetActive(false);
    }
    public void OnPointerDown(PointerEventData pointerEventData) // 버튼을 누를 시
    {
        Save();
        StartCoroutine(SaveInfo());
    }
    public void OnPointerUp(PointerEventData pointerEventData) // 버튼을 눌렀다가 뗄 시
    {

    }

    public void Save()
    {
        PlayerPrefs.SetString("Note1", inputNote1.text);
        PlayerPrefs.SetString("Note2", inputNote2.text);
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("Note1"))
        {
            inputNote1.text = PlayerPrefs.GetString("Note1");
            inputNote1.text = PlayerPrefs.GetString("Note1");
        }
    }

    IEnumerator SaveInfo()
    {
        SaveInfoText.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        SaveInfoText.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class PhonePadSubmit : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData pointerEventData) // 버튼을 누를 시
    {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.SubmitWord();
            }
            else
            {
                Debug.Log("Submitted successfully!");
            }
    }
    public void OnPointerUp(PointerEventData pointerEventData) // 버튼을 눌렀다가 뗄 시
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuExit : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject MenuPanel;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void OnPointerDown(PointerEventData pointerEventData) // ��ư�� ���� ��
    {
        MenuPanel.SetActive(false);
    }
    public void OnPointerUp(PointerEventData pointerEventData) // ��ư�� �����ٰ� �� ��
    {

    }

}

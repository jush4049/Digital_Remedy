using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GamePause : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private float rotationLimit = 40;
    [SerializeField] private float rotationSpeed = 15;

    private bool rotate = false;

    public GameObject GamePausePanel;
    public GameObject GamePauseButton;

    void Start()
    {
        GamePausePanel.SetActive(false);
    }
    void FixedUpdate() // 버튼을 누를 시 동작하는 간단한 버튼 애니메이션
    {
        float targetRotate = rotate ? rotationLimit : 0f;
        
        Quaternion target = Quaternion.Euler(targetRotate, 0, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
    }

    public void PasueOn() // 게임 일시정지 기능
    {
        Time.timeScale = 0;
    }

    public void OnPointerDown(PointerEventData pointerEventData) // 버튼을 누를 시
    {
        rotate = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData) // 버튼을 눌렀다가 뗄 시
    {
        rotate = false;
        PasueOn();
        GamePausePanel.SetActive(true);
        GamePauseButton.SetActive(false);
    }
}

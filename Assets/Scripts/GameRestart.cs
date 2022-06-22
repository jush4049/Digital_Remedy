using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameRestart : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float rotationLimit = 40;
    [SerializeField] private float rotationSpeed = 15;

    private bool rotate = false;

    public GameObject GamePausePanel;
    public GameObject GamePauseButton;

    void Start()
    {

    }
    void FixedUpdate() // 버튼을 누를 시 동작하는 간단한 버튼 애니메이션
    {
        float targetRotate = rotate ? rotationLimit : 0f;

        Quaternion target = Quaternion.Euler(targetRotate, 0, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
    }

    public void PasueOff() // 게임 일시정지 기능
    {
        Time.timeScale = 1;
    }

    public void OnPointerDown(PointerEventData pointerEventData) // 버튼을 누를 시
    {
        rotate = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData) // 버튼을 눌렀다가 뗄 시
    {
        rotate = false;
        PasueOff();
        GamePausePanel.SetActive(false);
        GamePauseButton.SetActive(true);
    }
}

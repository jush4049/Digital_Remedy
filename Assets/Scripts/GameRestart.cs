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
    void FixedUpdate() // ��ư�� ���� �� �����ϴ� ������ ��ư �ִϸ��̼�
    {
        float targetRotate = rotate ? rotationLimit : 0f;

        Quaternion target = Quaternion.Euler(targetRotate, 0, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
    }

    public void PasueOff() // ���� �Ͻ����� ���
    {
        Time.timeScale = 1;
    }

    public void OnPointerDown(PointerEventData pointerEventData) // ��ư�� ���� ��
    {
        rotate = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData) // ��ư�� �����ٰ� �� ��
    {
        rotate = false;
        PasueOff();
        GamePausePanel.SetActive(false);
        GamePauseButton.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Wrong : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Text CorrectText;
    [SerializeField] private float rotationLimit = 40;
    [SerializeField] private float rotationSpeed = 15;

    private bool rotate = false;

    void Start()
    {
    }
    void FixedUpdate() // ��ư�� ���� �� �����ϴ� ������ ��ư �ִϸ��̼�
    {
        float targetRotate = rotate ? rotationLimit : 0f;

        Quaternion target = Quaternion.Euler(targetRotate, 0, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
    }

    public IEnumerator GoCorrect()
    {
        CorrectText.text = "�����Դϴ�! �ٽ� ��󺸼���.";
        yield return new WaitForSeconds(3.0f);
        CorrectText.text = "���� �Ҹ��� ��ȳ���?";
    }
    public void OnPointerDown(PointerEventData pointerEventData) // ��ư�� ���� ��
    {
        rotate = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData) // ��ư�� �����ٰ� �� ��
    {
        rotate = false;
        StartCoroutine(GoCorrect());
    }
}

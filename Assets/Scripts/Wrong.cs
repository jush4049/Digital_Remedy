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
    void FixedUpdate() // 버튼을 누를 시 동작하는 간단한 버튼 애니메이션
    {
        float targetRotate = rotate ? rotationLimit : 0f;

        Quaternion target = Quaternion.Euler(targetRotate, 0, 0);

        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * rotationSpeed);
    }

    public IEnumerator GoCorrect()
    {
        CorrectText.text = "오답입니다! 다시 골라보세요.";
        yield return new WaitForSeconds(3.0f);
        CorrectText.text = "무슨 소리가 들렸나요?";
    }
    public void OnPointerDown(PointerEventData pointerEventData) // 버튼을 누를 시
    {
        rotate = true;
    }

    public void OnPointerUp(PointerEventData pointerEventData) // 버튼을 눌렀다가 뗄 시
    {
        rotate = false;
        StartCoroutine(GoCorrect());
    }
}

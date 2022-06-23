using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Correct : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
        CorrectText.text = "정답입니다!";
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene("Chapter8");
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


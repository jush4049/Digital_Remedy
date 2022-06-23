using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 토글버튼들 중 하나만 활성화되게 해주는 스크립트
public class ToggleButtonManager : MonoBehaviour
{
    public string selectedGameName;

    public GameObject[] toggleObjects;
    private Toggle[] toggles;

    private int activateCount = 0; // 현재 활성화된 토글버튼의 갯수

    private void Start()
    {

        initToggles();
        initActivateCount();
    }

    private void Update()
    {
        if (activateCount == 0)
            selectedGameName = "";
    }

    public string GetSelectedGameString()
    {
        return selectedGameName;
    }

    public void TryUpdateActivateCount(GameObject thisObject)
    {
        if(thisObject.GetComponent<Toggle>().isOn == true)
            selectedGameName = thisObject.name;

        Debug.Log(selectedGameName);

        updateActivateCount();

        if (activateCount > 1) // 활성화 된 버튼이 1개보다 많으면
        {
            offAllOtherButton(thisObject); // 클릭된버튼 외의 모든버튼 비활성화
        }
    }

    private void updateActivateCount()
    {
        activateCount = 0;
        // 활성화된 버튼의 수를 activateCount에 저장
        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn) activateCount++;
        }
    }

    private void offAllOtherButton(GameObject thisObject)
    {
        activateCount = 0;
        // 활성화된 버튼의 수를 activateCount에 저장
        foreach (GameObject toggleObject in toggleObjects)
        {
            if (toggleObject != thisObject)
            {
                toggleObject.GetComponent<Toggle>().isOn = false;
            }
        }
    }

    private void initActivateCount()
    {
        // 활성화된 버튼의 수를 activateCount에 저장
        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn) activateCount++;
        }
    }
    
    private void initToggles()
    {
        toggles = new Toggle[toggleObjects.Length];

        for(int index=0; index<toggleObjects.Length; index++)
        {
            toggles[index] = toggleObjects[index].GetComponent<Toggle>();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// ��۹�ư�� �� �ϳ��� Ȱ��ȭ�ǰ� ���ִ� ��ũ��Ʈ
public class ToggleButtonManager : MonoBehaviour
{
    public string selectedGameName;

    public GameObject[] toggleObjects;
    private Toggle[] toggles;

    private int activateCount = 0; // ���� Ȱ��ȭ�� ��۹�ư�� ����

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

        if (activateCount > 1) // Ȱ��ȭ �� ��ư�� 1������ ������
        {
            offAllOtherButton(thisObject); // Ŭ���ȹ�ư ���� ����ư ��Ȱ��ȭ
        }
    }

    private void updateActivateCount()
    {
        activateCount = 0;
        // Ȱ��ȭ�� ��ư�� ���� activateCount�� ����
        foreach (Toggle toggle in toggles)
        {
            if (toggle.isOn) activateCount++;
        }
    }

    private void offAllOtherButton(GameObject thisObject)
    {
        activateCount = 0;
        // Ȱ��ȭ�� ��ư�� ���� activateCount�� ����
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
        // Ȱ��ȭ�� ��ư�� ���� activateCount�� ����
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

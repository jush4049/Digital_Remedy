using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SightGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject choices;     // ������ ��ư ����
    [SerializeField]
    private List<GameObject> buttonList;     // ������ ��ư
    [SerializeField]
    private GameObject successWindow, failWindow;   // ���â
    [SerializeField]
    private Vector3 spawnPosition;  // ��ü ���� ��ġ
    [SerializeField]
    private float delayTime;        // ��ü�� �����Ǵ� �ð� ����

    private List<string> objectList;    // ��ü ����Ʈ
    private List<string> spawnObjectList;       // ������ ��ü �̸� ����Ʈ
    private List<Sprite> spriteList;            // ������ ��ü�� �̹��� ����Ʈ
    private List<GameObject> correctChoicesList;    // ������ ���� ���� ����Ʈ
    private List<GameObject> clickChoicesList;       // Ŭ���� ������ ����Ʈ

    private int spawnNum = 3;     // ������ ��ü ����

    // Start is called before the first frame update
    void Start()
    {
        objectList = new List<string>() { "Apple", "Banana", "Bread", "Cake", "Candy", "Cherry", "Corn", "Grape", "Kiwi", "Strawberry", "Watermelon" };
        spawnObjectList = new List<string>();
        spriteList = new List<Sprite>();
        correctChoicesList = new List<GameObject>();
        clickChoicesList = new List<GameObject>();

        SelectRandomObject();   // ������ 3���� ��ü ����
        StartCoroutine("SpawnObjectCoroutine"); // delayTime���� ��ü ����
    }

    // ������ 3���� ��ü ����
    private void SelectRandomObject()
    {
        string objectName;
        while(spawnObjectList.Count < spawnNum)
        {
            System.Random random = new System.Random();
            objectName = objectList[random.Next(objectList.Count)];
            if (spawnObjectList.Exists(x=>x== objectName))
                continue;
            spawnObjectList.Add(objectName);
        }
    }

    // delayTime���� ��ü ����
    IEnumerator SpawnObjectCoroutine()
    {
        List<GameObject> spawnList = new List<GameObject>();    // ������ ������Ʈ�� ���� ����Ʈ
        foreach (string objName in spawnObjectList)
        {
            GameObject prefab = Resources.Load("Prefabs/" + objName) as GameObject;
            spriteList.Add(prefab.GetComponent<SpriteRenderer>().sprite);
            spawnList.Add(Instantiate(prefab, spawnPosition, Quaternion.identity));
            yield return new WaitForSeconds(delayTime);
        }

        // �����ߴ� ������Ʈ �ı�
        foreach (GameObject obj in spawnList)
            Destroy(obj);

        SetChoices();   // �������� �̹��� ����
        ShowChoices();  // ������ �����ֱ�
    }

    // �������� �̹��� ����
    private void SetChoices()
    {
        GameObject button;
        System.Random random = new System.Random();
        foreach (Sprite sprite in spriteList)       // ���� �̹��� �������� ����
        {
            do
            {
                button = buttonList[random.Next(buttonList.Count)];
            } while (correctChoicesList.Exists(x => x == button));
            correctChoicesList.Add(button);
            button.transform.Find("Image").GetComponent<Image>().sprite = sprite;
        }

        // ������ ���������� ���� �̹��� ����
        foreach (GameObject btn in buttonList)
        {
            if (!correctChoicesList.Exists(x=>x==btn))  // btn�� ���� �̹����� ���õ��� ���� ������
            {
                string objectName;
                do
                {
                    objectName = objectList[random.Next(objectList.Count)];
                } while (spawnObjectList.Exists(x => x == objectName)); // ������ �ƴ� ��ü ����

                // ���� �̹����� ���õ��� ���� �������� ������ �ƴ� �̹��� ����
                GameObject prefab = Resources.Load("Prefabs/" + objectName) as GameObject;
                btn.transform.Find("Image").GetComponent<Image>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    // ��ü�� �� ���ư� �� ������ �����ֱ�
    private void ShowChoices()
    {
        choices.SetActive(true);
    }

    // ������ ��ư Ŭ��
    public void ClickChoiceButton()
    {
        Debug.Log("Ŭ��!");
        GameObject currentObj = EventSystem.current.currentSelectedGameObject;
        if (!clickChoicesList.Exists(x => x == currentObj))
        {
            clickChoicesList.Add(currentObj);
            TextMeshProUGUI order = currentObj.transform.Find("Order").GetComponent<TextMeshProUGUI>();
            order.text = clickChoicesList.Count.ToString();
        }

        ShowResult();
    }

    private void ShowResult()
    {
        if (clickChoicesList.Count == spawnNum) // ��� ���������� �������� Ȯ��
        {
            if (DecideAnswer())
            {
                successWindow.SetActive(true);
            }
            else
            {
                failWindow.SetActive(true);
            }
            choices.SetActive(false);
        }
    }

    private bool DecideAnswer()
    {
        for (int i = 0; i < spawnNum; i++)
        {
            if (!(clickChoicesList[i] == correctChoicesList[i]))
                return false;
        }
        return true;
    }

    // �ٽ� ���� Ŭ��
    public void ClickRestart()
    {
        failWindow.SetActive(false);

        // ����Ʈ �ʱ�ȭ
        spawnObjectList = new List<string>();
        spriteList = new List<Sprite>();
        correctChoicesList = new List<GameObject>();
        clickChoicesList = new List<GameObject>();

        // Ŭ�� ���� ǥ�� �ؽ�Ʈ �ʱ�ȭ
        foreach (GameObject btn in buttonList)
        {
            btn.transform.Find("Order").GetComponent<TextMeshProUGUI>().text = "";
        }

        SelectRandomObject();   // ������ 3���� ��ü ����
        StartCoroutine("SpawnObjectCoroutine"); // delayTime���� ��ü ����
    }
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SightGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject choices;     // 선택지 버튼 모음
    [SerializeField]
    private List<GameObject> buttonList;     // 선택지 버튼
    [SerializeField]
    private GameObject successWindow, failWindow;   // 결과창
    [SerializeField]
    private Vector3 spawnPosition;  // 물체 생성 위치
    [SerializeField]
    private float delayTime;        // 물체가 생성되는 시간 간격

    private List<string> objectList;    // 물체 리스트
    private List<string> spawnObjectList;       // 스폰할 물체 이름 리스트
    private List<Sprite> spriteList;            // 스폰한 물체의 이미지 리스트
    private List<GameObject> correctChoicesList;    // 선택지 순서 정답 리스트
    private List<GameObject> clickChoicesList;       // 클릭한 선택지 리스트

    private int spawnNum = 3;     // 스폰할 물체 개수

    // Start is called before the first frame update
    void Start()
    {
        objectList = new List<string>() { "Apple", "Banana", "Bread", "Cake", "Candy", "Cherry", "Corn", "Grape", "Kiwi", "Strawberry", "Watermelon" };
        spawnObjectList = new List<string>();
        spriteList = new List<Sprite>();
        correctChoicesList = new List<GameObject>();
        clickChoicesList = new List<GameObject>();

        SelectRandomObject();   // 스폰할 3개의 물체 고르기
        StartCoroutine("SpawnObjectCoroutine"); // delayTime마다 물체 스폰
    }

    // 스폰할 3개의 물체 고르기
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

    // delayTime마다 물체 스폰
    IEnumerator SpawnObjectCoroutine()
    {
        List<GameObject> spawnList = new List<GameObject>();    // 스폰한 오브젝트를 담을 리스트
        foreach (string objName in spawnObjectList)
        {
            GameObject prefab = Resources.Load("Prefabs/" + objName) as GameObject;
            spriteList.Add(prefab.GetComponent<SpriteRenderer>().sprite);
            spawnList.Add(Instantiate(prefab, spawnPosition, Quaternion.identity));
            yield return new WaitForSeconds(delayTime);
        }

        // 스폰했던 오브젝트 파괴
        foreach (GameObject obj in spawnList)
            Destroy(obj);

        SetChoices();   // 선택지에 이미지 세팅
        ShowChoices();  // 선택지 보여주기
    }

    // 선택지에 이미지 세팅
    private void SetChoices()
    {
        GameObject button;
        System.Random random = new System.Random();
        foreach (Sprite sprite in spriteList)       // 정답 이미지 선택지에 세팅
        {
            do
            {
                button = buttonList[random.Next(buttonList.Count)];
            } while (correctChoicesList.Exists(x => x == button));
            correctChoicesList.Add(button);
            button.transform.Find("Image").GetComponent<Image>().sprite = sprite;
        }

        // 나머지 선택지에는 오답 이미지 세팅
        foreach (GameObject btn in buttonList)
        {
            if (!correctChoicesList.Exists(x=>x==btn))  // btn이 아직 이미지가 세팅되지 않은 선택지
            {
                string objectName;
                do
                {
                    objectName = objectList[random.Next(objectList.Count)];
                } while (spawnObjectList.Exists(x => x == objectName)); // 정답이 아닌 물체 결정

                // 아직 이미지가 세팅되지 않은 선택지에 정답이 아닌 이미지 세팅
                GameObject prefab = Resources.Load("Prefabs/" + objectName) as GameObject;
                btn.transform.Find("Image").GetComponent<Image>().sprite = prefab.GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    // 물체가 다 날아간 후 선택지 보여주기
    private void ShowChoices()
    {
        choices.SetActive(true);
    }

    // 선택지 버튼 클릭
    public void ClickChoiceButton()
    {
        Debug.Log("클릭!");
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
        if (clickChoicesList.Count == spawnNum) // 모두 선택했으면 정답인지 확인
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

    // 다시 시작 클릭
    public void ClickRestart()
    {
        failWindow.SetActive(false);

        // 리스트 초기화
        spawnObjectList = new List<string>();
        spriteList = new List<Sprite>();
        correctChoicesList = new List<GameObject>();
        clickChoicesList = new List<GameObject>();

        // 클릭 순서 표시 텍스트 초기화
        foreach (GameObject btn in buttonList)
        {
            btn.transform.Find("Order").GetComponent<TextMeshProUGUI>().text = "";
        }

        SelectRandomObject();   // 스폰할 3개의 물체 고르기
        StartCoroutine("SpawnObjectCoroutine"); // delayTime마다 물체 스폰
    }
}

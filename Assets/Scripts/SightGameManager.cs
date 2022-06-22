using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject choices;     // 선택지
    [SerializeField]
    private Vector3 spawnPosition;  // 물체 생성 위치
    [SerializeField]
    private float delayTime;        // 물체마다 생성되는 시간 간격

    private List<string> objectList;    // 물체 리스트
    private List<string> spawnObjectList;       // 스폰할 물체 리스트
    private int spawnNum = 3;     // 스폰할 물체 개수

    // Start is called before the first frame update
    void Start()
    {
        objectList = new List<string>() { "Apple", "Banana", "Bread", "Cake", "Candy", "Cherry", "Corn", "Grape", "Kiwi", "Strawberry", "Watermelon" };
        spawnObjectList = new List<string>();
        SelectRandomObject();
        StartCoroutine("SpawnObjectCoroutine");
    }

    // 스폰할 3개의 물체 고르기
    private void SelectRandomObject()
    {
        string objectName;
        while(spawnObjectList.Count < 3)
        {
            System.Random random = new System.Random();
            objectName = objectList[random.Next(objectList.Count)];
            if (spawnObjectList.Exists(x=>x== objectName))
            {
                continue;
            }
            spawnObjectList.Add(objectName);
        }
    }

    // delayTime마다 물체 스폰
    IEnumerator SpawnObjectCoroutine()
    {
        foreach (string objName in spawnObjectList)
        {
            GameObject prefab = Resources.Load("Prefabs/" + objName) as GameObject;
            Instantiate(prefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(delayTime);
        }

        ShowChoices();
    }

    // 물체가 다 날아간 후 선택지 보여주기
    private void ShowChoices()
    {
        choices.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SightGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject choices;     // ������
    [SerializeField]
    private Vector3 spawnPosition;  // ��ü ���� ��ġ
    [SerializeField]
    private float delayTime;        // ��ü���� �����Ǵ� �ð� ����

    private List<string> objectList;    // ��ü ����Ʈ
    private List<string> spawnObjectList;       // ������ ��ü ����Ʈ
    private int spawnNum = 3;     // ������ ��ü ����

    // Start is called before the first frame update
    void Start()
    {
        objectList = new List<string>() { "Apple", "Banana", "Bread", "Cake", "Candy", "Cherry", "Corn", "Grape", "Kiwi", "Strawberry", "Watermelon" };
        spawnObjectList = new List<string>();
        SelectRandomObject();
        StartCoroutine("SpawnObjectCoroutine");
    }

    // ������ 3���� ��ü ����
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

    // delayTime���� ��ü ����
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

    // ��ü�� �� ���ư� �� ������ �����ֱ�
    private void ShowChoices()
    {
        choices.SetActive(true);
    }
}

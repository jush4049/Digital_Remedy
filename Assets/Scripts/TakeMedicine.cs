using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeMedicine : MonoBehaviour
{
    [SerializeField]
    private GameObject goalsWindow;
    [SerializeField]
    private TextMeshProUGUI redNumText, blueNumText;

    [SerializeField]
    private GameObject redPill;
    [SerializeField]
    private GameObject bluePill;

    [SerializeField]
    private int playTime;   // ���� ���� �ð�

    private int red, blue;  // �ึ�� �Ծ�� �ϴ� ����
    private int height, width;    // ȭ�� ũ��

    // Start is called before the first frame update
    void Start()
    {
        // ȭ�� ũ�� ���ϱ�
        height = (int)(Camera.main.orthographicSize);
        width = (int)(height * Camera.main.aspect);

        SetGoals();
    }

    private void SetGoals()
    {
        // ���� ��ǥ ����
        System.Random random = new System.Random();
        red = random.Next(2);
        blue = random.Next(2);
        if (red == 0 && blue == 0)  // �� �� 0���� ���� �ʰ�
            red = 1;

        // ��ǥ ǥ��
        redNumText.text = red.ToString();
        blueNumText.text = blue.ToString();
    }

    // ���� ��ǥ Ȯ�� ��ư Ŭ�� �޼ҵ�
    public void ClickCheckGoals()
    {
        goalsWindow.SetActive(false);
        StartCoroutine("SpawnPillCoroutine");
    }

    IEnumerator SpawnPillCoroutine()
    {
        Debug.Log("SpawnPillCoroutine");

        int spawnRed, spawnBlue;
        System.Random random = new System.Random();

        for (int i = 0; i < playTime; i++)
        {
            // ������ �� ���� ����
            spawnRed = random.Next(1, 3);
            spawnBlue = random.Next(1, 3);
            Debug.Log(spawnRed + " " + spawnBlue);

            // �� ����
            for (int j = 0; j < spawnRed; j++)
                Instantiate(redPill, new Vector3((float)random.NextDouble() * width * 2 - width, (float)random.NextDouble() * height * 2 - height, 0), Quaternion.identity);
            for (int j = 0; j < spawnBlue; j++)
                Instantiate(bluePill, new Vector3((float)random.NextDouble() * width * 2 - width, (float)random.NextDouble() * height * 2 - height, 0), Quaternion.identity);


            yield return new WaitForSeconds(1.0f);
        }
    }
}

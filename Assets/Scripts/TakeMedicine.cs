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
    private TextMeshProUGUI redScoreText, blueScoreText;

    [SerializeField]
    private GameObject redPill;
    [SerializeField]
    private GameObject bluePill;

    [SerializeField]
    private int playTime;   // ���� ���� �ð�

    private int red, blue;  // �ึ�� �Ծ�� �ϴ� ����
    private int height, width;    // ȭ�� ũ��
    private int redScore, blueScore;    // ���� �� ����

    private Vector3 mousePosition;  // Ŭ���� ��ǥ
    private float maxDistance = 15f;

    // Start is called before the first frame update
    void Start()
    {
        // ȭ�� ũ�� ���ϱ�
        height = (int)(Camera.main.orthographicSize);
        width = (int)(height * Camera.main.aspect);

        SetGoals();
    }

    // ����ڰ� �� Ŭ���ϸ� ���� ����
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // Ŭ���� ��ǥ
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, maxDistance);
            if (hit)
            {
                if (hit.transform.gameObject.name == "RedPill(Clone)")  // ���� �� Ŭ��
                {
                    redScore++;
                    redScoreText.text = redScore.ToString();
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.gameObject.name == "BluePill(Clone)")  // �Ķ� �� Ŭ��
                {
                    blueScore++;
                    blueScoreText.text = blueScore.ToString();
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }

    private void SetGoals()
    {
        // ���� ��ǥ ����
        System.Random random = new System.Random();
        red = random.Next(4);
        blue = random.Next(4);
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
        int spawnRed, spawnBlue;
        System.Random random = new System.Random();

        for (int i = 0; i < playTime; i++)
        {
            // ������ �� ���� ����
            spawnRed = random.Next(1, 3);
            spawnBlue = random.Next(1, 3);

            // �� ����
            for (int j = 0; j < spawnRed; j++)
                Instantiate(redPill, new Vector3((float)random.NextDouble() * width * 2 - width, (float)random.NextDouble() * height * 2 - height, 0), Quaternion.identity);
            for (int j = 0; j < spawnBlue; j++)
                Instantiate(bluePill, new Vector3((float)random.NextDouble() * width * 2 - width, (float)random.NextDouble() * height * 2 - height, 0), Quaternion.identity);


            yield return new WaitForSeconds(1.0f);
        }
    }
}

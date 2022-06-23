using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeMedicine : MonoBehaviour
{
    [SerializeField]
    private GameObject successWindow, failWindow;
    [SerializeField]
    private GameObject goalsWindow;
    [SerializeField]
    private TextMeshProUGUI redNumText, blueNumText;
    [SerializeField]
    private TextMeshProUGUI redScoreText, blueScoreText;
    [SerializeField]
    private TextMeshProUGUI remainTimeText;

    // �� ������
    [SerializeField]
    private GameObject redPill;
    [SerializeField]
    private GameObject bluePill;

    [SerializeField]
    private int playTime;   // ���� ���� �ð�

    private int redGoal, blueGoal;  // �ึ�� �Ծ�� �ϴ� ����
    private int height, width;    // ȭ�� ũ��
    private int redScore, blueScore;    // ���� �� ����
    private int remainTime; // ���� �ð�

    private Vector3 mousePosition;  // Ŭ���� ��ǥ
    private float maxDistance = 15f;

    // Start is called before the first frame update
    void Start()
    {
        // ȭ�� ũ�� ���ϱ�
        height = (int)(Camera.main.orthographicSize);
        width = (int)(height * Camera.main.aspect);

        // ���� �ð� ����
        remainTime = playTime;
        remainTimeText.text = remainTime.ToString();

        SetGoals(); // ��ǥ ����
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
        redGoal = random.Next(4);
        blueGoal = random.Next(4);
        if (redGoal == 0 && blueGoal == 0)  // �� �� 0���� ���� �ʰ�
            redGoal = 1;

        // ��ǥ ǥ��
        redNumText.text = redGoal.ToString();
        blueNumText.text = blueGoal.ToString();
    }

    // ���� ��ǥ Ȯ�� ��ư Ŭ�� �޼ҵ�
    public void ClickCheckGoals()
    {
        goalsWindow.SetActive(false);
        StartCoroutine("SpawnPillCoroutine");
    }

    // �� ����
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

            // ���� �ð� ������Ʈ
            remainTime--;
            remainTimeText.text = remainTime.ToString();
        }

        EndGame();
    }

    private void EndGame()
    {
        SetResult();
    }

    private void SetResult()
    {
       if (CheckSuccess())
        {
            successWindow.SetActive(true);
        }
        else
        {
            failWindow.SetActive(true);
        }
    }

    // ���� ���� ���� Ȯ���ϱ�
    private bool CheckSuccess()
    {
        // ���� ���� ������ ��ǥ�� ��ġ�ϴ��� Ȯ��
        if (redScore == redGoal && blueScore == blueGoal)
            return true;
        else
            return false;
    }

    public void ClickRestart()
    {
        failWindow.SetActive(false);

        // ���� �ð� ����
        remainTime = playTime;
        remainTimeText.text = remainTime.ToString();

        // ���ھ� �ʱ�ȭ
        redScore = blueScore = 0;
        redScoreText.text = blueScoreText.text = "0";

        goalsWindow.SetActive(true);
        SetGoals(); // ��ǥ ����
    }
}

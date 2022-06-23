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
    private int playTime;   // 게임 진행 시간

    private int red, blue;  // 약마다 먹어야 하는 수량
    private int height, width;    // 화면 크기
    private int redScore, blueScore;    // 먹은 약 개수

    private Vector3 mousePosition;  // 클릭한 좌표
    private float maxDistance = 15f;

    // Start is called before the first frame update
    void Start()
    {
        // 화면 크기 구하기
        height = (int)(Camera.main.orthographicSize);
        width = (int)(height * Camera.main.aspect);

        SetGoals();
    }

    // 사용자가 약 클릭하면 점수 증가
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);    // 클릭한 좌표
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, maxDistance);
            if (hit)
            {
                if (hit.transform.gameObject.name == "RedPill(Clone)")  // 빨간 약 클릭
                {
                    redScore++;
                    redScoreText.text = redScore.ToString();
                    Destroy(hit.transform.gameObject);
                }
                if (hit.transform.gameObject.name == "BluePill(Clone)")  // 파란 약 클릭
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
        // 게임 목표 설정
        System.Random random = new System.Random();
        red = random.Next(4);
        blue = random.Next(4);
        if (red == 0 && blue == 0)  // 둘 다 0개가 되지 않게
            red = 1;

        // 목표 표시
        redNumText.text = red.ToString();
        blueNumText.text = blue.ToString();
    }

    // 게임 목표 확인 버튼 클릭 메소드
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
            // 스폰할 약 개수 결정
            spawnRed = random.Next(1, 3);
            spawnBlue = random.Next(1, 3);

            // 약 스폰
            for (int j = 0; j < spawnRed; j++)
                Instantiate(redPill, new Vector3((float)random.NextDouble() * width * 2 - width, (float)random.NextDouble() * height * 2 - height, 0), Quaternion.identity);
            for (int j = 0; j < spawnBlue; j++)
                Instantiate(bluePill, new Vector3((float)random.NextDouble() * width * 2 - width, (float)random.NextDouble() * height * 2 - height, 0), Quaternion.identity);


            yield return new WaitForSeconds(1.0f);
        }
    }
}

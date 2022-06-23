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
    private int playTime;   // 게임 진행 시간

    private int red, blue;  // 약마다 먹어야 하는 수량
    private int height, width;    // 화면 크기

    // Start is called before the first frame update
    void Start()
    {
        // 화면 크기 구하기
        height = (int)(Camera.main.orthographicSize);
        width = (int)(height * Camera.main.aspect);

        SetGoals();
    }

    private void SetGoals()
    {
        // 게임 목표 설정
        System.Random random = new System.Random();
        red = random.Next(2);
        blue = random.Next(2);
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
        Debug.Log("SpawnPillCoroutine");

        int spawnRed, spawnBlue;
        System.Random random = new System.Random();

        for (int i = 0; i < playTime; i++)
        {
            // 스폰할 약 개수 결정
            spawnRed = random.Next(1, 3);
            spawnBlue = random.Next(1, 3);
            Debug.Log(spawnRed + " " + spawnBlue);

            // 약 스폰
            for (int j = 0; j < spawnRed; j++)
                Instantiate(redPill, new Vector3((float)random.NextDouble() * width * 2 - width, (float)random.NextDouble() * height * 2 - height, 0), Quaternion.identity);
            for (int j = 0; j < spawnBlue; j++)
                Instantiate(bluePill, new Vector3((float)random.NextDouble() * width * 2 - width, (float)random.NextDouble() * height * 2 - height, 0), Quaternion.identity);


            yield return new WaitForSeconds(1.0f);
        }
    }
}

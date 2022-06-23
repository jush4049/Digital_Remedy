using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SentenceGameManager : MonoBehaviour
{
    public Canvas canvas1;  //캔버스
    public Canvas canvas2;

    /*public GameObject choice1;  //선택지 버튼
    public GameObject choice2;*/
    /*public List<Button> buttonList1;  //선택지 버튼
    public List<Button> buttonList2;

    public Text btnText;
*/
    public List<TextMeshProUGUI> btnText1;
    public List<TextMeshProUGUI> btnText2;

    private List<string> wordList1;  //원래 리스트
    private List<string> wordList2;  //원래 리스트

    private List<string> mixList1;  //랜덤 돌린 리스트
    private List<string> mixList2;  //랜덤 돌린 리스트

    public List<Button> clickChoicesList1;  //사용자가 선택한 리스트
    public List<Button> clickChoicesList2;  //사용자가 선택한 리스트

    // Start is called before the first frame update
    void Start()
    {
        /*canvas2 = GetComponent<Canvas>();
        canvas1 = GetComponent<Canvas>();
*/
        canvas2.enabled = false;
        canvas1.enabled = true;
        wordList1 = new List<string>() { "저의", "발표주제는", "디지털 치료제" };
        wordList2 = new List<string>() { "독성 및 부작용", "저렴한 비용으로", "대량 공급이" };
        
        Mix();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Mix()  //wordList1이랑 wordList2 둘다 믹스하기
    {
        List<string> newList = new List<string>();

        int count1 = wordList1.Count;
        int count2 = wordList2.Count;

        for(int i=0; i<count1; i++)
        {
            int rand = Random.Range(0, count1-1);
            newList.Add(wordList1[rand]);
        }
        mixList1 = newList;

        for(int i=0; i<count2; i++)
        {
            int rand = Random.Range(0, count2 - 1);
            newList.Add(wordList2[rand]);
        }
        mixList2 = newList;

        AppendButtonText();
    }

    void AppendButtonText()  //랜덤으로 돌린 문자열 버튼에 붙이기
    {
        for(int i=0; i<mixList1.Count; i++)
        {
            btnText1[i].text = mixList1[i];
        }

        for (int i = 0; i < mixList2.Count; i++)
        {
            btnText2[i].text = mixList2[i];
        }
    }

}

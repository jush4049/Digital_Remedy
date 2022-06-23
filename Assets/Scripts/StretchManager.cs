using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StretchManager : MonoBehaviour
{
    [SerializeField]
    private Image humanImage;
    [SerializeField]
    private TextMeshProUGUI instruction;
    [SerializeField]
    private List<Sprite> imageList;
    [SerializeField]
    private List<string> instructionList;
    [SerializeField]
    private int stretchTime;    // 스트레칭 시간
    [SerializeField]
    private int stretchNum;  // 스트레칭할 개수


    private List<int> orderList;    // 스트레칭 순서
    private int stretchKind;     // 스트레칭 종류

    // Start is called before the first frame update
    void Start()
    {
        stretchKind = imageList.Count;
        orderList = new List<int>();
        SelectOrder();  // 스트레치 순서 정하기
    }

    private void SelectOrder()
    {
        int idx;
        System.Random random = new System.Random();
        while (orderList.Count < stretchNum)
        {
            idx = random.Next(stretchKind);
            if (orderList.Exists(x => x == idx))
                continue;
            orderList.Add(idx);
        }
        StartCoroutine("SetImageCoroutine");
    }

    IEnumerator SetImageCoroutine()
    {
        yield return new WaitForSeconds(stretchTime);
        for (int i = 0; i < stretchNum; i++)
        {
            humanImage.GetComponent<Image>().sprite = imageList[orderList[i]];
            instruction.text = instructionList[orderList[i]];
            yield return new WaitForSeconds(stretchTime);
        }
    }
}

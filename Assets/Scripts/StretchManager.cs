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
    private int stretchTime;    // ��Ʈ��Ī �ð�
    [SerializeField]
    private int stretchNum;  // ��Ʈ��Ī�� ����


    private List<int> orderList;    // ��Ʈ��Ī ����
    private int stretchKind;     // ��Ʈ��Ī ����

    // Start is called before the first frame update
    void Start()
    {
        stretchKind = imageList.Count;
        orderList = new List<int>();
        SelectOrder();  // ��Ʈ��ġ ���� ���ϱ�
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

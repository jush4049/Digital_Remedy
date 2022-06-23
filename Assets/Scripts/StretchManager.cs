using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StretchManager : MonoBehaviour
{
    [SerializeField] GameObject successWindow, failWindow;  // ���â
    [SerializeField]
    private Image humanImage;   // ��Ʈ��Ī ����
    [SerializeField]
    private TextMeshProUGUI instruction;    // ���ù� �ؽ�Ʈ
    [SerializeField]
    private GameObject choices;     // ������ ��ư ����
    [SerializeField]
    private List<GameObject> buttonList;    // ȭ�鿡 ��ġ�� ������ ��ư ����Ʈ

    [SerializeField]
    private List<Sprite> imageList; // ��Ʈ��Ī ���� ����Ʈ
    [SerializeField]
    private List<string> instructionList;   // ���ù� ����Ʈ
    [SerializeField]
    private int stretchTime;    // ��Ʈ��Ī �ð�
    [SerializeField]
    private int stretchNum;  // ��Ʈ��Ī�� ����


    private List<GameObject> correctChoicesList;    // ������ ���� ���� ����Ʈ
    private List<GameObject> clickChoicesList;       // Ŭ���� ������ ����Ʈ

    private List<int> orderList;    // ��Ʈ��Ī ����
    private int stretchKind;     // ��Ʈ��Ī ����

    // Start is called before the first frame update
    void Start()
    {
        stretchKind = imageList.Count;

        orderList = new List<int>();
        correctChoicesList = new List<GameObject>();
        clickChoicesList = new List<GameObject>();
        
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
        SetChoices();
        ShowChoices();
    }

    // ��ü�� �� ���ư� �� ������ �����ֱ�
    private void ShowChoices()
    {
        choices.SetActive(true);
    }

    // �������� �̹��� ����
    private void SetChoices()
    {
        GameObject button;
        System.Random random = new System.Random();
        foreach (int idx in orderList)       // ���� �̹��� �������� ����
        {
            do
            {
                button = buttonList[random.Next(buttonList.Count)];
            } while (correctChoicesList.Exists(x => x == button));
            correctChoicesList.Add(button);
            button.transform.Find("Image").GetComponent<Image>().sprite = imageList[idx];
        }
    }

    // ������ ��ư Ŭ��
    public void ClickChoiceButton()
    {
        Debug.Log("Ŭ��!");
        GameObject currentObj = EventSystem.current.currentSelectedGameObject;
        if (!clickChoicesList.Exists(x => x == currentObj))
        {
            clickChoicesList.Add(currentObj);
            TextMeshProUGUI order = currentObj.transform.Find("Order").GetComponent<TextMeshProUGUI>();
            order.text = clickChoicesList.Count.ToString();
        }

        ShowResult();
    }

    private void ShowResult()
    {
        if (clickChoicesList.Count == stretchNum) // ��� ���������� �������� Ȯ��
        {
            if (DecideAnswer())
            {
                successWindow.SetActive(true);
            }
            else
            {
                failWindow.SetActive(true);
            }
        }
    }

    private bool DecideAnswer()
    {
        for (int i = 0; i < stretchNum; i++)
        {
            if (!(clickChoicesList[i] == correctChoicesList[i]))
                return false;
        }
        return true;
    }

    public void GoScene()
    {

    }

    public void Restart()
    {
        failWindow.SetActive(false);

        // ����Ʈ �ʱ�ȭ
        orderList = new List<int>();
        correctChoicesList = new List<GameObject>();
        clickChoicesList = new List<GameObject>();

        // ���� ���߱� â �ʱ�ȭ
        choices.SetActive(false);
        foreach (GameObject btn in buttonList)  // Ŭ�� ���� ǥ�� �ؽ�Ʈ �ʱ�ȭ
            btn.transform.Find("Order").GetComponent<TextMeshProUGUI>().text = "";

        SelectOrder();  // ��Ʈ��ġ ���� ���ϱ�
    }
}

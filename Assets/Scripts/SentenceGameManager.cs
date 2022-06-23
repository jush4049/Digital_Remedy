using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SentenceGameManager : MonoBehaviour
{
    public Canvas canvas1;  //ĵ����
    public Canvas canvas2;

    /*public GameObject choice1;  //������ ��ư
    public GameObject choice2;*/
    /*public List<Button> buttonList1;  //������ ��ư
    public List<Button> buttonList2;

    public Text btnText;
*/
    public List<TextMeshProUGUI> btnText1;
    public List<TextMeshProUGUI> btnText2;

    private List<string> wordList1;  //���� ����Ʈ
    private List<string> wordList2;  //���� ����Ʈ

    private List<string> mixList1;  //���� ���� ����Ʈ
    private List<string> mixList2;  //���� ���� ����Ʈ

    public List<Button> clickChoicesList1;  //����ڰ� ������ ����Ʈ
    public List<Button> clickChoicesList2;  //����ڰ� ������ ����Ʈ

    // Start is called before the first frame update
    void Start()
    {
        /*canvas2 = GetComponent<Canvas>();
        canvas1 = GetComponent<Canvas>();
*/
        canvas2.enabled = false;
        canvas1.enabled = true;
        wordList1 = new List<string>() { "����", "��ǥ������", "������ ġ����" };
        wordList2 = new List<string>() { "���� �� ���ۿ�", "������ �������", "�뷮 ������" };
        
        Mix();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Mix()  //wordList1�̶� wordList2 �Ѵ� �ͽ��ϱ�
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

    void AppendButtonText()  //�������� ���� ���ڿ� ��ư�� ���̱�
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

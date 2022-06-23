using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField]  int a;
    [SerializeField]  string s;
    [SerializeField] public Text PrintText;
    // Start is called before the first frame update
    void Start()
    {
        int a = 1;
        string s = a.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void ResultSubmit()
    {
        if (PrintText.Equals(s))
        {
            Debug.Log("1¹ø ÀÔ·Â");
        }
    }
}

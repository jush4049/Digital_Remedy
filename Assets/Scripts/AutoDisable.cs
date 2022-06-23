using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    private float waitingTime;
    public float disableTime;

    private void Awake()
    {
        waitingTime = 0.0f;
    }

    private void Update()
    {
        waitingTime += Time.deltaTime;

        if(waitingTime >= disableTime)
        {
            gameObject.SetActive(false);
            waitingTime = 0.0f;
        }
    }
}

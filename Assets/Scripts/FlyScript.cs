using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyScript : MonoBehaviour
{
    private float gravity = 9.8f;
    private float mVelocity = 0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = this.transform.position;
        mVelocity += gravity * Time.deltaTime;

        pos.y -= mVelocity * Time.deltaTime;
        this.transform.position = pos;
    }

}

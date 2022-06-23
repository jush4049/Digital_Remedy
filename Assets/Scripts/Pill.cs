using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    private float lifeTime;   // 화면에 나타나는 시간

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        lifeTime = (float)random.NextDouble() + 1;   // 1-2초간 나타남
        StartCoroutine("DestroyCoroutine");
    }

    // lifeTime이 지나면 파괴
    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}

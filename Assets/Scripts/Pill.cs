using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
    private float lifeTime;   // ȭ�鿡 ��Ÿ���� �ð�

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();
        lifeTime = (float)random.NextDouble() + 1;   // 1-2�ʰ� ��Ÿ��
        StartCoroutine("DestroyCoroutine");
    }

    // lifeTime�� ������ �ı�
    IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }
}

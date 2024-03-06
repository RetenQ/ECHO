using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("�������")]
    [SerializeField] private Rigidbody2D rb;

    // �ӵ�

    public float damage;
    public float maxLifeTime;
    public string targetStr;
    public string ignoreStr;

    [SerializeField] private bool isActive = true; 
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (maxLifeTime >= 0.001f)
        {
            maxLifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetBullet(float _damage)
    {
        this.damage = _damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision);
        //ע���ӵ������󲻻�ݻ�
        if(isActive)
        {
            if(collision.CompareTag("Wall"))
            {
                //����ǽ��ֻͣ����
                rb.velocity = Vector3.zero;
            }

            if (collision.CompareTag(targetStr))
            {
                collision.gameObject.GetComponent<BaseObj>().Hurt(damage);  //����˺�

                rb.velocity = Vector3.zero;

                //Destroy(gameObject);
            }
            else if (!collision.CompareTag(ignoreStr))
            {
                //Destroy(gameObject);
            }



            // ��֤�ӵ�ֻ�ᱻ����һ��
            isActive = false;
        }

    }
}

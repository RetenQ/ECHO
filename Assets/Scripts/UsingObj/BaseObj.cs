using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseObj : MonoBehaviour
{
    [Header("������ֵ")]
    public float maxHp;
    public float nowHp;

    public float attack; // ���������������ֱ�ӱ�ʾ�ɹ����л��ж����˺� 
    public float speed;

    private void Awake()
    {
        nowHp = maxHp;  // ��ʼ������Ϊ���ֵ
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(nowHp <= 0)
        {
            Death();
        }

        ObjUpdate();
    }

    public virtual void ObjUpdate()
    {
        // ÿһ��Obj�Լ���Update

    }

    public virtual void Death()
    {

    }

    public virtual void Hurt(float _damage)
    {
        nowHp = _damage;
    }
    
}

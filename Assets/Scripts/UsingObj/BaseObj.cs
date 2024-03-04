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


    [Header("������Ӧ����")]
    public bool isRhyObj = false; //�Ƿ��ǿ�����Ӧ���������
    public bool isRhyAct = false;

    private void Awake()
    {
        nowHp = maxHp;  // ��ʼ������Ϊ���ֵ
    }

    // Start is called before the first frame update
    void Start()
    {
        if(isRhyObj)
        {
            // ������ڽ���ϵͳ�е����壬��Ҫע��
            RhythmMgr.GetInstance().RegistertObj(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(nowHp <= 0)
        {
            Death();
        }

        if(isRhyObj)
        {
            if(isRhyAct)
            {
                RhyAction(); 
                isRhyAct=false;
            }
        }

        ObjUpdate();
    }

    public virtual void ObjUpdate()
    {
        // ÿһ��Obj�Լ���Update

    }

    public void Death()
    {
        if (isRhyObj)
        {
            RhythmMgr.GetInstance().RemoveObj(this); // ���ע��
        }

        ObjDeath();
    }

    public virtual void ObjDeath()
    {
        // ����������������ʱ��Ķ������
    }

    public virtual void Hurt(float _damage)
    {
        nowHp = _damage;
    }

    public void RhyActOn()
    {
        // ��Rhy�����򿪣������ͷ�ʱ������Update�н���
        isRhyAct = true;
    }

    public virtual void RhyAction()
    {
        // ��Ӧ����ϵͳ�ľ������
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *    
 *    
    protected override void ObjAwake()
    {

    }

    protected override void ObjStart()
    {

    }

    protected override void ObjUpdate()
    {
        
    }
*/

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
        ObjAwake();


    }

    protected virtual void ObjAwake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        if(isRhyObj)
        {
            // ������ڽ���ϵͳ�е����壬��Ҫע��
            RhythmMgr.GetInstance().RegistertObj(this);
        }
        ObjStart();
    }

    protected virtual void ObjStart()
    {

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

    protected virtual void ObjUpdate()
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
        if(gameObject.CompareTag("Wall"))
        {
            // Ŀǰ����ǽ���˺�
        }
        else
        {
            
            nowHp -= _damage;
        }
    }

    public virtual void Heal(float _heal)
    {
        if(nowHp + _heal <= maxHp)
        {
            nowHp += _heal;
        }

        if(nowHp > maxHp)
        {
            nowHp = maxHp;
        }
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

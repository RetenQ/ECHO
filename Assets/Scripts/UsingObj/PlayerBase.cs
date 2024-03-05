using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : Chara
{
    [Header("Player����")]
    [SerializeField] private bool islock = false; //����ʱ�޷�����
    [SerializeField] private bool isdash = false; 
    private Vector2 movement;


    [Header("���")]
    public Rigidbody2D rb;
    public Collider2D col;
    public Animator animator;

    protected override void ObjAwake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    protected override void ObjStart()
    {

    }

    protected override void ObjUpdate()
    {
        if(!islock)
        {
            if (!isdash)
            {
                //�ǳ��״̬�½��еĲ���
                Movement();

                //����Ĵ�����Ϊ�˷���֮ǰ��ʱ���Գ�̶����е�
                /*            if (Input.GetKeyDown(KeyCode.LeftShift) && dashTimer <= 0)
                            {
                                soundMgr.ClipPlay(2);
                                isdash = true;
                                startDashTimer = maxDashTime;

                                dashTimer = dashCD;
                            }*/
            }
            else
            {

                // ���Mode
                /*            startDashTimer -= Time.deltaTime;
                            if (startDashTimer <= 0)
                            {
                                isdash = false;

                            }
                            else
                            {
                                rb.velocity = movement * dashSpeed;  
                            }*/
            }

            if (Input.GetMouseButtonDown(0))
            {
                //���
            }

            if (Input.GetMouseButtonDown(1))
            {
                //�Ҽ�
            }
        } 
    }

    public bool Movement()
    {

        // ����movement�Ĳ���
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //�� ע��GetAxisRawֻ����{-1 ,0 , 1}�������ֱ��Ż���ϣ�������ɾ���������ʹ��GetAxisRaw

        Debug.Log(movement.x + " | " +  movement.y);

        //!Ĭ�ϳ�50
        rb.MovePosition(rb.position + movement * speed * Time.deltaTime *50);
        //����ֱ��ʹ��MovePosition
        //��Ϊ�Ƿ���Update��������Ҫÿ֡���ƣ�����ʹ��deltaTime


        // anim.SetBool("isRun",true);
        if (movement.x != 0 || movement.y != 0)
        {
            //��������
            if (movement.x < 0)
            {
                transform.localScale = new Vector3(-(movement.x), transform.localScale.y, transform.localScale.z);
                
            }

            if (movement.x > 0)
            {
                transform.localScale = new Vector3(-(movement.x), transform.localScale.y, transform.localScale.z);
            }

            return true;
        }
        else
        {
            return false;
            //��ʾ���û���ƶ�
        }
    }
}

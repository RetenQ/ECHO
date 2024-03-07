using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : Chara
{

    [Header("Player����")]
    [SerializeField] private bool inRhy; // �Ƿ��ڽ�������
    [SerializeField] private bool islock = false; //����ʱ�޷�����
    [SerializeField] private bool isdash = false; 
    private Vector2 movement;
    [SerializeField] private Vector2 lastMovement;//���һ�η�0����

    public Vector2 mouseLocation;
    private Vector2 ToMouseDirection;

    [Header("�������")]
    public float dashCD = 2;
    public float dashMul;  // �˴���dash�ļ��ٱ���
    [SerializeField] private float dashTimer = -99f;
    public float maxDashTime = 1.5f;
    public float stopDashTime = 0.1f; //��ÿ����ֶ�ֹͣ
    [SerializeField] private float startDashTimer;


    [Header("�ӵ���")]
    public GameObject bullet;
    public Transform firePosition;
    public float bulletSpeed; 

    [Header("���")]
    public Rigidbody2D rb;
    public Collider2D col;
    public Animator animator;
    public SpriteRenderer sr;

    [Header("��������")]
    public int RightD; 
    public int ErrorD; 

    protected override void ObjAwake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    protected override void ObjStart()
    {
/*        sr.color = Color.blue;
*/
    }

    protected override void ObjUpdate()
    {
        // ������
        if(Input.GetKeyDown(KeyCode.K)) {
            if (inRhy)
            {
                RightD++;
            }
            else
            {
                ErrorD++;
            }
        }

        Debug.Log("R:" + RightD + " || E:" + ErrorD);


        DataUpdater();

        if (!islock)
        {
            if (!isdash)
            {
                //�ǳ��״̬�½��еĲ���
                Movement();

                if (Input.GetKeyDown(KeyCode.LeftControl) && dashTimer <= 0)
                {
                    isdash = true;
                    startDashTimer = maxDashTime; // Timer����Ϊ�����ʱ�䵹��ʱ

                    dashTimer = dashCD;
                }
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.LeftControl) && startDashTimer <= maxDashTime - stopDashTime)
                {
                    // ����������ٴΰ��³��
                    startDashTimer = 0;
                    isdash = false;

                }

                // ���Mode
                    startDashTimer -= Time.deltaTime;
                    if (startDashTimer <= 0)
                    {
                        // ʱ�䵽�˽���״̬
                        isdash = false;

                    }
                    else
                    {

                        // ���ڳ��״̬�½��г��
                        // ����λ��ʹ�õ�������ƶ��ķ���
                        rb.velocity = lastMovement * speed * dashMul;  
                    }
            }

            if (Input.GetMouseButtonDown(0))
            {
                //���
                Fire();
            }

            if (Input.GetMouseButtonDown(1))
            {
                //�Ҽ�
            }
        } 
    }

    private void FixedUpdate()
    {
        FiexdDataUpdater();
    }

    public bool Movement()
    {

        // ����movement�Ĳ���
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if(movement.x !=0 || movement.y !=0)
        {
            lastMovement = movement; //��¼�����
        }

        //�� ע��GetAxisRawֻ����{-1 ,0 , 1}�������ֱ��Ż���ϣ�������ɾ���������ʹ��GetAxisRaw

        // ֱ��ʹ��velocity�����ã������������
        //!Ĭ�ϳ�50
       // rb.MovePosition(rb.position + movement * speed * Time.deltaTime *50);
        //����ֱ��ʹ��MovePosition
        //��Ϊ�Ƿ���Update��������Ҫÿ֡���ƣ�����ʹ��deltaTime

        rb.velocity = new Vector2(movement.x * speed  , movement.y *speed);


        // anim.SetBool("isRun",true);
        if (movement.x != 0 || movement.y != 0)
        {
            //��������
            //�˴�Ĭ�Ͻ�ɫ�������Ҳ�
            if (movement.x > 0)
            {
                transform.localScale = new Vector3(movement.x, transform.localScale.y, transform.localScale.z);
                
            }

            if (movement.x < 0)
            {
                transform.localScale = new Vector3(movement.x, transform.localScale.y, transform.localScale.z);
            }

            return true;
        }
        else
        {
            return false;
            //��ʾ���û���ƶ�
        }
    }

    private void DataUpdater()
    {
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ToMouseDirection = (mouseLocation - new Vector2(transform.position.x, transform.position.y)).normalized;
    }

    private void FiexdDataUpdater()
    {
        // ��Ҫ׼ȷ��ʱ�����ݷ�������
        if (dashTimer >= 0)
        {
            // isdash = false;
            dashTimer -= Time.deltaTime;
        }
    }


    private void Fire()
    {
        GameObject bullet_temp = Instantiate(bullet, firePosition.position, Quaternion.identity);
        bullet_temp.GetComponent<Bullet>().SetBullet(attack);
        bullet_temp.GetComponent<Rigidbody2D>().AddForce(ToMouseDirection * bulletSpeed, ForceMode2D.Impulse);
    }

    public void PlayerRhyOn()
    {
        Debug.Log("ON");
        inRhy = true;
        sr.color = Color.red; 
    }

    public void PlayerRhyOff()
    {
        Debug.Log("OFF!");

        inRhy = false;
        sr.color = Color.blue;

    }
}

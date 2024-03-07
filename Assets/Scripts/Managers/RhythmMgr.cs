using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����BGM�Ķ���
public class RhythmMgr : SingletonMono<RhythmMgr>
{
    [Header("BGM������")]
    public float RhyTolerance;
    public float RhyToleranceTimer;
    public float RhyBgmName;
    public float RhyInterval; // �ĵ���������ʹ�ò�������ܻ����� 
    public float RhyIntervalTimer; 
    [SerializeField] private bool isAvive = false;
    [SerializeField] private bool playerRhy = false;

    [Header("ע����")]
    [SerializeField]private GameObject Player; 
    [SerializeField]private PlayerBase PlayerSc; 
    public List<BaseObj> Objs;

    protected override void Awake()
    {
        base.Awake();
        Objs = new List<BaseObj>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player"); 
        PlayerSc = Player.GetComponent<PlayerBase>();
        RhyToleranceTimer = RhyTolerance;
        RhyIntervalTimer = RhyInterval;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isAvive)
        {
            if (RhyToleranceTimer <= 0.0f)
            {
                //��ʼ
                RhyMgrStart();
                RhyToleranceTimer = RhyTolerance;


            }
            else
            {
                RhyToleranceTimer -= Time.fixedDeltaTime;
            }
        }
        else
        {
            if(RhyIntervalTimer > 0.0f)
            {
                RhyIntervalTimer -= Time.fixedDeltaTime;
                
/*                if((RhyIntervalTimer <= RhyTolerance) && (playerRhy == false))
                {
                    PlayerRhyOn();//����
                }else if((RhyIntervalTimer <= RhyInterval-RhyTolerance) &&(playerRhy == true) )
                {
                    PlayerRhyOff(); 

                   //�ر�
                }*/


                if((RhyIntervalTimer <= RhyInterval - RhyTolerance)&& (RhyIntervalTimer > RhyTolerance) && (playerRhy == true)){
                    PlayerRhyOff();
                }else if((RhyIntervalTimer <= RhyTolerance) && (playerRhy == false))
                {
                    PlayerRhyOn();//����

                }
            }
            else
            {
                // RhyIntervalTimer��0��֪ͨ����λ
                NotifyObjs();
                RhyIntervalTimer = RhyInterval;

            }

        }



    }

    private void RhyMgrStart()
    {
        isAvive = true; 
        // ����
    }

    // ����Obj
    public void RegistertObj(BaseObj obj)
    {
        Objs.Add(obj);
    }

    public void RemoveObj(BaseObj obj)
    {
        Objs.Remove(obj);
    }
   
    public void NotifyObjs()
    {
        foreach (BaseObj _obj in Objs)
        {
            _obj.RhyActOn(); 
        }
    }

    public void PlayerRhyOn()
    {
        playerRhy = true;
        PlayerSc.PlayerRhyOn();
    }

    public void PlayerRhyOff()
    {
        playerRhy = false;
        PlayerSc.PlayerRhyOff();
    }

    /// <summary>
    /// ֪ͨ���еģ���AI���Ƶģ���Ҫ�ڽ�����Ͻ��в�����Object������Ӧ
    /// </summary>
    public void SystemRhy()
    {
        NotifyObjs(); //֪ͨ
    }
}

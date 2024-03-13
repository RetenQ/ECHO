using SonicBloom.Koreo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����BGM�Ķ���
public class RhythmMgr : SingletonMono<RhythmMgr>
{
    [Header("BGM������")]
    [SerializeField]private bool isActive = false;
    public string eventID;
    public float RhyTolerance; // isRhyΪTrue���֮��Ļ�false
    public float RhyToleranceTimer ;
    public float delayPlayer ; // һ��ʼ�ӳٲ���

    public bool isRhy = false; 



    [Header("ע����")]
    [SerializeField]private GameObject Player; 
    [SerializeField]private PlayerBase PlayerSc; 
    public List<BaseObj> Objs;

    [Header("���")]
    public AudioSource AudioSource;

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
        AudioSource = GetComponent<AudioSource>();

/*        RhyInterval = (60 / RhyBpm) * RhyMul;
        Debug.Log(("!!! : || " + RhyInterval));

        RhyToleranceTimer = RhyTolerance;
        RhyIntervalTimer = RhyInterval;*/

        // kore
        Koreographer.Instance.RegisterForEvents(eventID, DrumBeat); // ע��

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isActive)
        {
            if(delayPlayer <=0)
            {
                RhyMgrStart();

            }
            else
            {
                delayPlayer -= Time.fixedDeltaTime;
            }
        }

        if (isRhy)
        {
            if(RhyToleranceTimer >= 0)
            {
                RhyToleranceTimer -= Time.fixedDeltaTime;
            }
            else
            {
                PlayerRhyOff();

            }
        }

    }

    private void DrumBeat(KoreographyEvent koreographyEvent)
    {
        // ���ĵ��˸�ʲô    
        NotifyObjs();
        PlayerRhyOn(); 
    }



    private void RhyMgrStart()
    {
        isActive = true;
        AudioSource.Play();
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
        Debug.Log("ON RHY");
        isRhy = true; //����ΪTrue
        // playerRhy = true;
        PlayerSc.PlayerRhyOn();
    }

    public void PlayerRhyOff()
    {
        Debug.Log("OFF RHY");

        isRhy = false;
        RhyToleranceTimer = RhyTolerance; 
        // playerRhy = false;
        PlayerSc.PlayerRhyOff();
    }

    /// <summary>
    /// ֪ͨ���еģ���AI���Ƶģ���Ҫ�ڽ�����Ͻ��в�����Object������Ӧ
    /// </summary>
    public void SystemRhy()
    {
        NotifyObjs(); //֪ͨ
    }



    /*
     * 
     *     [Header("BGM������_�ɰ�")]
    // public float RhyTolerance;
    public float RhyBgmName;

    public float RhyBpm;
    public float RhyMul; 

    public float RhyInterval; // �ĵ���������ʹ�ò�������ܻ����� 
    public float RhyIntervalTimer; 
    [SerializeField] private bool isAvive = false;
    [SerializeField] private bool playerRhy = false;
     * 
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
                }


                if((RhyIntervalTimer <= RhyInterval - RhyTolerance)&& (RhyIntervalTimer > RhyTolerance) && (playerRhy == true)){
                    PlayerRhyOff();
                        }else if ((RhyIntervalTimer <= RhyTolerance) && (playerRhy == false))
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
     
     */
}

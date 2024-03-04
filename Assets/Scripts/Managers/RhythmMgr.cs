using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����BGM�Ķ���
public class RhythmMgr : SingletonMono<RhythmMgr>
{

    [Header("ע����")]
    public List<BaseObj> Objs;

    protected override void Awake()
    {
        base.Awake();
        Objs = new List<BaseObj>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
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

    }

    public void PlayerRhyOff()
    {

    }

    /// <summary>
    /// ֪ͨ���еģ���AI���Ƶģ���Ҫ�ڽ�����Ͻ��в�����Object������Ӧ
    /// </summary>
    public void SystemRhy()
    {
        NotifyObjs(); //֪ͨ
    }
}

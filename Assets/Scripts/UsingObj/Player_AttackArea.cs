using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Player_AttackArea : MonoBehaviour
{
    [Header("������ֵ")]
    [SerializeField] private bool isAttack = false;  // �����ظ�����
    [SerializeField] private float attack;
    [SerializeField] public Animator animator;

    [SerializeField] private int playerfacing; // ����

    public float attackRange = 5f;
    private Collider2D[] enemiesInRange;

    [SerializeField] private bool wasInTransition = true; // ���ڼ�¼��һ֡�Ƿ���״̬ת����
    
    public PlayerBase playerSC;


    public float maxAttackTime;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
/*        // ��鵱ǰ����״̬�Ƿ��ڽ���״̬���л�״̬
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        bool isInTransition = animator.IsInTransition(0);

        // �����ǰ����״̬ת���У�������һ֡��ת���У����ʾ�����ոս��������л�
        if (stateInfo.normalizedTime >= 1f ||(!isInTransition && wasInTransition))
        {
            StopAttack(); // ���ú���A
        }

        // ����wasInTransition��ֵ��������һ֡���ж�
        wasInTransition = isInTransition;*/
    }

    // PlayerBase���͹���->PlayerBase�޸�isAttack = false ->
    // StartAttackִ�й��� , ִ��֮���޸�isAttack = true-> һ������ʱִ��StopAttack
    // -> StopAttackִ�ж�Ӧ����

    private void OnEnable()
    {
        StartAttack();
    }

    private void StartAttack()
    {
        if(isAttack == false)
        {
            // ������PlayerBase���ţ���

            // ִ�в��� 
            // ���ֶ�������Trigger��Χ���
            // ��ⷶΧ�ڵ����е���
            enemiesInRange = Physics2D.OverlapCircleAll(transform.position, attackRange);

            foreach (Collider2D enemyCollider in enemiesInRange)
            {
                if (enemyCollider.CompareTag("Enemy"))
                {
                    // ��¼�ڹ�����Χ�ڵĵ���
                    //Debug.Log("Enemy detected: " + enemyCollider.gameObject.name);

                }
            }
            
            isAttack = true;
        }

    }

    private void StopAttack()
    {
        gameObject.SetActive(false); // �ص�
        playerSC.isAttack = false; 
    }

    public void setAttackArea(float _attack , int _facing , PlayerBase _player)
    {
        this.playerfacing = _facing;
        this.attack = _attack; // ΪPlayerBase�õ�
        this.isAttack = false; // �Զ����û�û����

        this.playerSC = _player;       
    }


    void OnDrawGizmosSelected()
    {
        // �ڱ༭���л��ƹ�����Χ
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

}

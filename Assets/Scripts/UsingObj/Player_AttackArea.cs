using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_AttackArea : MonoBehaviour
{
    [Header("������ֵ")]
    [SerializeField] private bool isAttack = false;  // �����ظ�����
    [SerializeField] private float attack;


    public void setAttackArea(float _attack)
    {
        this.attack = _attack; // ΪPlayerBase�õ�
    }


}

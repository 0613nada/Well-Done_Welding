using Febucci.UI.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ��������


    public Vector2 inputVec;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator animator;

    // �÷��̾� �ӵ�
    public float speed;

    private void Awake()
    {
        // �� �ʱ�ȭ
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ���Ͱ��� ��ǲ:Horizontal, Vertical������ �Է¹���
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // �÷��̾� �̵�
        rigid.velocity = inputVec.normalized * speed;
    }

    private void LateUpdate()
    {
        // �ִϸ��̼� ������ ����
        animator.SetFloat("Speed", inputVec.magnitude);


        if (inputVec.x != 0)
        {
            // ĳ���� ������ȯ
            spriter.flipX = inputVec.x < 0;
        }
    }
}

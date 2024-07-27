using Febucci.UI.Actions;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    // ��������

    Vector2 mousePos;
    Vector2 inputVec;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator animator;
    Camera camera;
    // �÷��̾� �ӵ�
    public float PlayerSpeed;


    private void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }
    private void Awake()
    {
        // �� �ʱ�ȭ
        PlayerSpeed = 100;
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // ���콺Ŀ�� �ΰ��� �ν�
        mousePos = Input.mousePosition;
        mousePos = camera.ScreenToWorldPoint(mousePos);
        // ���Ͱ��� ��ǲ:Horizontal, Vertical������ �Է¹���
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // �÷��̾� �̵�
        rigid.velocity = (inputVec.normalized * 2.5f) * (PlayerSpeed / 100);
    }

    private void LateUpdate()
    {
        // �ִϸ��̼� ������ ����
        animator.SetFloat("Speed", inputVec.magnitude);

        // ���콺 ��ġ�� ���� ĳ���� ���� ����
        spriter.flipX = mousePos.x < transform.position.x;
        
    }

    
}

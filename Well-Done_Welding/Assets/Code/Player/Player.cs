using Febucci.UI.Actions;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;

     //transferScene - transferPoint �� ����
    public string currentPoint;

    // ��������
    Vector2 mousePos;
    Vector2 inputVec;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator animator;
    Camera cam;
    public PlayerUi playerUi;
    // �÷��̾� �ӵ�
    public float PlayerSpeed;

    public float dashSpeed = 15f;
    public float dashTime = 0.2f;
    private Vector3 dashDirection;
    private bool isDashing = false;
    private float dashTimer;

    private void Start()
    {
        if(instance == null)
        {            
            PlayerSpeed = 100;
            rigid = GetComponent<Rigidbody2D>();
            spriter = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            cam = GameObject.Find("Main Camera").GetComponent<Camera>();

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //�÷��̾� �������� ����
            Destroy(this.gameObject);
        }        
    }

    private void Update()
    {
        // ���콺Ŀ�� �ΰ��� �ν�
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        // ���Ͱ��� ��ǲ:Horizontal, Vertical������ �Է¹���
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");

        
        if (Input.GetMouseButtonDown(1) && !isDashing && playerUi.dashCount != 0)
        {
            playerUi.dashCount--;
            StartDash();
        }

        if (isDashing)
        {
            Dash();
        }
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

    //�뽬 �����غ�
    void StartDash()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        dashDirection = (mousePosition - transform.position).normalized;
        isDashing = true;
        dashTimer = dashTime;
    }
    // �뽬
    void Dash()
    {
        transform.position += dashDirection * dashSpeed * Time.deltaTime;
        dashTimer -= Time.deltaTime;
        

        if (dashTimer <= 0)
        {
            isDashing = false;
        }
    }


}

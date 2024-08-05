using Febucci.UI.Actions;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Player : MonoBehaviour
{
    static public Player instance;

     //transferScene - transferPoint 값 저장
    public string currentPoint;

    // 변수선언
    Vector2 mousePos;
    Vector2 inputVec;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator animator;
    Camera cam;
    public PlayerUi playerUi;
    // 플레이어 속도
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
            //플레이어 복제생성 방지
            Destroy(this.gameObject);
        }        
    }

    private void Update()
    {
        // 마우스커서 인게임 인식
        mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        // 벡터값을 인풋:Horizontal, Vertical값으로 입력받음
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
        // 플레이어 이동
        rigid.velocity = (inputVec.normalized * 2.5f) * (PlayerSpeed / 100);        
    }

    private void LateUpdate()
    {
        // 애니매이션 움직임 구현
        animator.SetFloat("Speed", inputVec.magnitude);

        // 마우스 위치에 따라 캐릭터 방향 변경
        spriter.flipX = mousePos.x < transform.position.x;
        
    }

    //대쉬 사전준비
    void StartDash()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        dashDirection = (mousePosition - transform.position).normalized;
        isDashing = true;
        dashTimer = dashTime;
    }
    // 대쉬
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

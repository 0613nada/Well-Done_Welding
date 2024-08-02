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
    // 플레이어 속도
    public float PlayerSpeed;

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

    
}

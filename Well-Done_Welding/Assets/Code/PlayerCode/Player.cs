using Febucci.UI.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // 변수선언


    public Vector2 inputVec;
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator animator;

    // 플레이어 속도
    public float speed;

    private void Awake()
    {
        // 값 초기화
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // 벡터값을 인풋:Horizontal, Vertical값으로 입력받음
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        // 플레이어 이동
        rigid.velocity = inputVec.normalized * speed;
    }

    private void LateUpdate()
    {
        // 애니매이션 움직임 구현
        animator.SetFloat("Speed", inputVec.magnitude);


        if (inputVec.x != 0)
        {
            // 캐릭터 방향전환
            spriter.flipX = inputVec.x < 0;
        }
    }
}

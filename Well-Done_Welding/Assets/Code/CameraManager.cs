using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    static public CameraManager instance;

    public GameObject target; // 카메라가 따라갈 대상
    public float moveSpeed; // 카메라 속도
    private Vector3 targetPosition; // 대상의 현재 위치값

    void Start()
    {
        if(instance == null)
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        

    }

    void Update()
    {
        //플레이어 추적
        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x , target.transform.position.y, this.transform.position.z);

            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}

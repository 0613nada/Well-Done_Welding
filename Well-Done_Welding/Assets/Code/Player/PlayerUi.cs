using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    public int dashCount;
    public int playerDashCount;
    public float dashCoolTime;
    public float dashMaxTime;

    Slider DashSlider;
    public GameObject dash1;
    public GameObject dash2;

    private bool isCharging = false;

    private void Awake()
    {
        dashCoolTime = 5f;
        dashMaxTime = dashCoolTime;
        dashCount = 0;
        playerDashCount = 2;
        DashSlider  = GetComponent<Slider>();
   
        
    }    
    void LateUpdate()
    {
        //��� ���� �ڷ�ƾ ����
        if (dashCount < playerDashCount && !isCharging)
        {
            StartCoroutine(DashCharge());
        }

        // �뽬���������� ���� UI
        switch (dashCount)
        {
            case 0:
                dash1.SetActive(false);
                dash2.SetActive(false);
                
               
                break;
            case 1:
                dash1.SetActive(true);
                dash2.SetActive(false);             
                break;
            case 2:
                dash1.SetActive(true);
                dash2.SetActive(true);
                
                break;
            case 3:
                break;
        }
    }

   // ��� ���� �ڷ�ƾ
    IEnumerator DashCharge()
    {
        isCharging = true;

        while (dashCoolTime > 0)
        {
            dashCoolTime -= Time.deltaTime;
            DashSlider.value = dashCoolTime / dashMaxTime;
            yield return null;
        }

        dashCount++;
        dashCoolTime = dashMaxTime;
        isCharging = false;
    }
}

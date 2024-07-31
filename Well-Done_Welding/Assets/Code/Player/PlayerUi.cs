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

    private void Awake()
    {
        dashCoolTime = 5;
        dashMaxTime = 5;
        dashCount = 0;
        playerDashCount = 2;
        DashSlider  = GetComponent<Slider>();
   
        
    }    
    void LateUpdate()
    {
        StartCoroutine(DashCharge());
        // 대쉬보유갯수에 따른 UI
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

   
    IEnumerator DashCharge()
    {
        if (dashCount == playerDashCount)
            yield break;
        while (dashCoolTime > 0)
        {
                   
            
            dashCoolTime -= Time.deltaTime;

            DashSlider.value = dashCoolTime / dashMaxTime;

            if (dashCoolTime <= 0)
            {
                dashCount++;
                dashCoolTime = dashMaxTime;
                
            }
            yield break;
        }
        

    }
}

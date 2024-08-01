using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    public string startPoint;
    private Player thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<Player>();

        if(startPoint == thePlayer.currentPoint)
        {
            thePlayer.transform.position = this.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

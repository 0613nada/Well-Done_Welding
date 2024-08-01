using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferScene : MonoBehaviour
{
    public string transferSceneName;//�̵��� �� �̸�
    public string transferPoint;// �̵��� ��ġ
    private Player thePlayer;

    void Start()
    {
        thePlayer = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision. gameObject.name == "Player")
        {
            thePlayer.currentPoint = transferPoint;
            SceneManager.LoadScene(transferSceneName);
        }
    }
}

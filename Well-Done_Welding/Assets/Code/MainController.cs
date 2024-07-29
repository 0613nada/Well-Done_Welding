using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class MainController : MonoBehaviour
{
    [SerializeField]
    Button gameStartBtn;
    [SerializeField]
    Button optionBtn;
    [SerializeField]
    Button exitBtn;
    [SerializeField]
    Button returnBtn_1;
    [SerializeField]
    Button returnBtn_2;
    [SerializeField]
    GameObject soundOption;
    [SerializeField]
    GameObject displayOption;
    [SerializeField]
    GameObject controlOption;

    public void SaveSlotBtn()
    {
        LoadingController.LoadScene("Ground");
    }

    public void PlayBtn() //게임시작 버튼 이벤트
    {
        gameStartBtn.gameObject.SetActive(false);
        returnBtn_1.gameObject.SetActive(true);
        optionBtn.interactable = false;
        exitBtn.interactable = false;
    }

    public void OptionBtn() //옵션 버튼 이벤트
    {
        optionBtn.gameObject.SetActive(false);
        returnBtn_2.gameObject.SetActive(true);
        gameStartBtn.interactable = false;
        exitBtn.interactable = false;
    }

    public void ReturnBtn_1() //게임시작-돌아가기 버튼 이벤트
    {
        returnBtn_1.gameObject.SetActive(false);
        gameStartBtn.gameObject.SetActive(true);
        optionBtn.interactable = true;
        exitBtn.interactable = true;
    }

    public void ReturnBtn_2() //옵션-돌아가기 버튼 이벤트
    {
        returnBtn_2.gameObject.SetActive(false);
        optionBtn.gameObject.SetActive(true);
        gameStartBtn.interactable = true;
        exitBtn.interactable = true;

    }

    public void SoundOptionBtn()//소리옵션 버튼 이벤트
    {
        displayOption.gameObject.SetActive(false);
        controlOption.gameObject.SetActive(false);
        soundOption.gameObject.SetActive(true);
    }

    public void DisplayOptionBtn()//화면옵션 버튼 이벤트
    {
        displayOption.gameObject.SetActive(true);
        controlOption.gameObject.SetActive(false);
        soundOption.gameObject.SetActive(false);
    }

    public void ControlOptionBtn()//조작법옵션 버튼 이벤트
    {
        displayOption.gameObject.SetActive(false);
        controlOption.gameObject.SetActive(true);
        soundOption.gameObject.SetActive(false);
    }

}

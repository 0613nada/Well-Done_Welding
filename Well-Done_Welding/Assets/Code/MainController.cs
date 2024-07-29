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

    public void PlayBtn() //���ӽ��� ��ư �̺�Ʈ
    {
        gameStartBtn.gameObject.SetActive(false);
        returnBtn_1.gameObject.SetActive(true);
        optionBtn.interactable = false;
        exitBtn.interactable = false;
    }

    public void OptionBtn() //�ɼ� ��ư �̺�Ʈ
    {
        optionBtn.gameObject.SetActive(false);
        returnBtn_2.gameObject.SetActive(true);
        gameStartBtn.interactable = false;
        exitBtn.interactable = false;
    }

    public void ReturnBtn_1() //���ӽ���-���ư��� ��ư �̺�Ʈ
    {
        returnBtn_1.gameObject.SetActive(false);
        gameStartBtn.gameObject.SetActive(true);
        optionBtn.interactable = true;
        exitBtn.interactable = true;
    }

    public void ReturnBtn_2() //�ɼ�-���ư��� ��ư �̺�Ʈ
    {
        returnBtn_2.gameObject.SetActive(false);
        optionBtn.gameObject.SetActive(true);
        gameStartBtn.interactable = true;
        exitBtn.interactable = true;

    }

    public void SoundOptionBtn()//�Ҹ��ɼ� ��ư �̺�Ʈ
    {
        displayOption.gameObject.SetActive(false);
        controlOption.gameObject.SetActive(false);
        soundOption.gameObject.SetActive(true);
    }

    public void DisplayOptionBtn()//ȭ��ɼ� ��ư �̺�Ʈ
    {
        displayOption.gameObject.SetActive(true);
        controlOption.gameObject.SetActive(false);
        soundOption.gameObject.SetActive(false);
    }

    public void ControlOptionBtn()//���۹��ɼ� ��ư �̺�Ʈ
    {
        displayOption.gameObject.SetActive(false);
        controlOption.gameObject.SetActive(true);
        soundOption.gameObject.SetActive(false);
    }

}

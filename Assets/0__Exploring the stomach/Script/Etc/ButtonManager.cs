using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject[] npcText;
    public GameObject Btn_Talk;
    public GameObject canvas_Manual;

    private CFirebase firebase;
    
    private int count = 0;

    public bool isFirstNumber = true;
    public bool isSecodsNumber = false;

    public string firstNumber;
    public string secondsNumber;
    public string amountNumber;
    public int numberCount = 0;

    public GameObject Img_Menu;
    public GameObject Hand_Menu_Canvas;
    public GameObject Img_Scene;
    public GameObject Img_Title;

    public Text displayText;
    public Text genderText;

    void Start()
    {
        firebase = FindObjectOfType<CFirebase>();
        UpdateDisplayText();
    }

    public void NpcText()
    {
        // 현재 대화를 비활성화합니다.
        npcText[count].SetActive(false);

        count++;

        // 모든 대화가 끝났을 경우
        if (count >= npcText.Length)
        {
            // 대화창을 닫습니다.
            CloseDialogue();
        }
        else
        {
            // 다음 대화를 활성화합니다.
            npcText[count].SetActive(true);
        }
    }

    // 대화창을 닫는 함수
    void CloseDialogue()
    {
        // 대화창을 비활성화합니다.
        foreach (GameObject textObject in npcText)
        {
            textObject.SetActive(false);
        }
        
        // 대화 버튼을 비활성화합니다.
        Btn_Talk.SetActive(false);
    }

    public void StomachManual()
    {
        canvas_Manual.SetActive(false);

    }

    public void Man()
    {
        firebase.genders = "man";
        UpdateGenderText("남자");
    }
    
    public void Woman()
    {
        firebase.genders = "woman";
        UpdateGenderText("여자");
    }

    public void Decide()
    {
        Img_Title.SetActive(true);
        //firebase.ageNumber = int.Parse(amountNumber);
        //firebase.UpdateUsers();
        // Reset();
        
    }

    public void Number_0() { AddNumber("0"); }
    public void Number_1() { AddNumber("1"); }
    public void Number_2() { AddNumber("2"); }
    public void Number_3() { AddNumber("3"); }
    public void Number_4() { AddNumber("4"); }
    public void Number_5() { AddNumber("5"); }
    public void Number_6() { AddNumber("6"); }
    public void Number_7() { AddNumber("7"); }
    public void Number_8() { AddNumber("8"); }
    public void Number_9() { AddNumber("9"); }

    private void AddNumber(string number)
    {
        amountNumber += number; // 입력된 숫자를 누적
        if (amountNumber.Length > 2)
        {
            amountNumber = number; // 초기화하고 현재 숫자를 추가
        }
        UpdateDisplayText();  // 추가: 텍스트 업데이트
    }

    private void UpdateDisplayText() // 추가: 텍스트를 업데이트하는 메서드
    {
        if(displayText != null)
        {
            displayText.text = amountNumber;
        }
    }

    private void UpdateGenderText(string gender) // 성별 텍스트를 업데이트하는 메서드
    {
        if(genderText != null)
        {
            genderText.text = gender;
        }
    }


    public void Reset()
    {
        isFirstNumber = true;
        isSecodsNumber = false;
        numberCount = 0;
        amountNumber = "";
    }

    public void GameStart()
    {
        Hand_Menu_Canvas.SetActive(false);
    }

    public void Introduce()
    {
        Hand_Menu_Canvas.SetActive(false);
        Img_Scene.SetActive(true);

    }

    public void Menu()
    {
        Hand_Menu_Canvas.SetActive(false);
        Img_Menu.SetActive(true);
    }

    public void MenualClose()
    {
        Img_Menu.SetActive(false);
        Img_Scene.SetActive(false);
        Hand_Menu_Canvas.SetActive(true);

    }

}
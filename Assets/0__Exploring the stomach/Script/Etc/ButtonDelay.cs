using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonDelay : MonoBehaviour
{
    public Button button; // 버튼을 참조하기 위한 변수
    private bool isButtonInteractable = true; // 버튼 상호 작용 가능 여부

    void Start()
    {
        Button btn = button.GetComponent<Button>(); // 버튼 컴포넌트 가져오기
        btn.onClick.AddListener(TaskOnClick); // 클릭 이벤트에 함수 추가
    }

    void TaskOnClick()
    {
        if (isButtonInteractable) // 버튼이 상호 작용 가능한 상태인 경우에만 실행
        {
            isButtonInteractable = false; // 버튼 비활성화
            button.interactable = false; // 버튼 비활성화

            // 2초 후에 버튼을 다시 활성화
            Invoke("EnableButton", 3f);

            // 여기에 원하는 동작 추가
            Debug.Log("Button Clicked");
        }
    }

    void EnableButton()
    {
        isButtonInteractable = true; // 버튼 상호 작용 가능 상태로 변경
        button.interactable = true; // 버튼을 활성화
    }
}
using UnityEngine;
using UnityEngine.UI;

public class TextTyping : MonoBehaviour
{
    public Text npcText; // TMP_Text 오브젝트를 받기 위함.
    public string npcTalk;

    private int currrentIndex = 0;
    public float typingSpeed = 0.05f;

    void Start()
    {
        StartText();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextTalk();
        }
    }

    void StartText()
    {
        currrentIndex = 0;
        npcText.text = ""; // text 초기화
        InvokeRepeating("NextTalk", 0, typingSpeed); // 반복.
    }

    void NextTalk()
    {
        if (currrentIndex < npcTalk.Length)
        {
            npcText.text += npcTalk[currrentIndex]; // 글자만큼의 숫자를 하나씩 text에 집어 넣기 위함.
            currrentIndex++;
        }
        else
        {
            CancelInvoke("NextTalk"); // Invoke함수 cancel.
        }
    }
}

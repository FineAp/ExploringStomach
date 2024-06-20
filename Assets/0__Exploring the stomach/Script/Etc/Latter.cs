using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Latter : MonoBehaviour
{
    public int time = 10;
    public Button btn;
    public Button img;

    void Start()
    {
        StartCoroutine(StartFadeCoroutine());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            LatterBtn();
        }
    }

    public void LatterBtn()
    {
        print("Click");
        btn.gameObject.SetActive(false);
        img.gameObject.SetActive(true);

    }

    IEnumerator StartFadeCoroutine()
    {
        yield return new WaitForSeconds(time); // 2초 대기
        
        btn.gameObject.SetActive(true);
        StartCoroutine(FadeCoroutine());
    }

    IEnumerator FadeCoroutine()
    {
        // Button 컴포넌트의 이미지를 가져옴
        Image btnImage = btn.GetComponent<Image>();

        float fadeCount = 0;
        while (fadeCount < 1.0f)
        {
            fadeCount += 0.01f;
            yield return new WaitForSeconds(0.007f);
            btnImage.color = new Color(1f, 1f, 1f, fadeCount); // 버튼의 이미지 컬러를 변경
        }
    }

        
}

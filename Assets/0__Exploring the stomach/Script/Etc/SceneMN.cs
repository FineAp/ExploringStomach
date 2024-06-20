using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMN : MonoBehaviour
{
    //IN MOUSE SCENE

    public void ReturnToMain()
    {
        SceneManager.LoadScene("0___MAIN___");
    }
    public void ReturnToMouse()
    {
        SceneManager.LoadScene("1___MOUSE___");
    }

    public void ToStomach()
    {
        SceneManager.LoadScene("2___STOMACH___");
    }
    
    public void ToInsting()
    {
        SceneManager.LoadScene("3___INTESTING___");

    }

    public void ToLarge()
    {
        SceneManager.LoadScene("4___LARGE___");
    }

    public void ToPoo()
    {
        SceneManager.LoadScene("5___POO___");
    }

    public void ToClear()
    {
        SceneManager.LoadScene("6___CLEAR___");
    }

    public void QuitGame()
    {
        Application.Quit(); // 게임 종료 함수 호출
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ToStomach();
        }
    }




}

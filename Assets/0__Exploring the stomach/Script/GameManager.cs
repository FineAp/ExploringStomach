using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text scoreWin;

    public GameObject[] hpImg;
    public int hp = 4;

    public float time = 100f;
    public Text timeText;
    public bool isTime = false;

    private CFirebase firebase;

    //LargeScene
    public GameObject[] SpawnEenemy;
    public GameObject Canvas_Score;
    public GameObject Canvas_Lose;
    public GameObject Large_win_Btn;
    public SceneMN scenes;
    

    void Start()
    {
        firebase = FindObjectOfType<CFirebase>();
        score = 0;
        isTime = false;
    }

    void Update()
    {
        ScoreText();
        HpManager();

        if(isTime)
        {
            if(time > 0)
            {
                time -= Time.deltaTime;
                Timer(time);
            }

            else
            {
                LargeWin();
                print("win");
                time = 0;
                isTime = false;
            }
        }
    

    }


    void ScoreText()
    {
        scoreText.text = score.ToString();
        scoreWin.text = score.ToString();
    }

    public void HpManager()
    {
        if (hp >= 0 && hp < hpImg.Length)
        {
            hpImg[hp].SetActive(false);

            if(hp == 0)
            {
                LargeFaile();
            }
        }

        else
        {
            return;
        }

    }

    void Timer(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes,seconds);

    }


    void LargeWin()
    {
        //FirebaseUpdate();
        Destroy(SpawnEenemy[0]);
        Destroy(SpawnEenemy[1]);
        Canvas_Score.SetActive(false);
        Large_win_Btn.SetActive(true);
    }


    //대장씬.
    void LargeFaile()
    {
        //FirebaseUpdate();
        Canvas_Score.SetActive(false);
        Canvas_Lose.SetActive(true);
        Invoke("LargeReStart", 5f);
    }

    void LargeReStart()
    {
        scenes.ToLarge();
    }

    void FirebaseUpdate()
    {
        // firebase.score = score;
        firebase.UpdateUsers();
    }

}

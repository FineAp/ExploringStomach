using UnityEngine;
using System.Collections;
using UnityEngine.UI;  // Don't forget to include this namespace

public class LargeDelay : MonoBehaviour
{
    public GameObject Spawm;
    public GameManager game;
    public GameObject Canvas_Score;

    public GameObject dacong;
    public GameObject afterDacong;

    public Text countdownText; // Reference to the Text component for countdown
    public GameObject canvas_Time;

    private float countdownTime = 10f;

    void Start()
    {
        // Start the countdown coroutine
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (countdownTime > 0)
        {
            countdownText.text = countdownTime.ToString("F0") + "초"; // Update the text component
            yield return new WaitForSeconds(1f); // Wait for 1 second
            countdownTime--;
        }

        // Hide the countdown text when it reaches zero
        countdownText.gameObject.SetActive(false);
        canvas_Time.SetActive(false);

        // Execute the delay function
        Delay();
    }

    void Delay()
    {
        Canvas_Score.SetActive(true);
        game.isTime = true;

        dacong.SetActive(false);
        afterDacong.SetActive(true);

        Spawm.SetActive(true);
    }
}

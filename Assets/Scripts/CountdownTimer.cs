using MoreMountains.CorgiEngine;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float currentTime;
    public float startingTime;
    public float UpdateInterval = 0.3f;
    private Text timerText;
    private float timeLeft;

    private void Start()
    {
        timerText = gameObject.GetComponent<Text>();
        currentTime = startingTime;
        timeLeft = UpdateInterval;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0.0)
        {
            timerText.text = currentTime.ToString("0");
            timeLeft = UpdateInterval;
        }

        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            foreach (var player in LevelManager.Instance.Players)
            {
                LevelManager.Instance.KillPlayer(player);
            }

            gameObject.SetActive(false);
        }
    }
}

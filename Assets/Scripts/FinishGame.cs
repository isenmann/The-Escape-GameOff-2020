using MoreMountains.CorgiEngine;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    public StartRocket startRocket;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        var player = string.Empty;

        if (collision.transform.name.Contains("Player1"))
        {
            player = "player one";
            if(LevelManager.Instance.Players[1] != null)
            {
                LevelManager.Instance.KillPlayer(LevelManager.Instance.Players[1]);
            }
        }

        if (collision.transform.name.Contains("Player2"))
        {
            player = "player two";
            if (LevelManager.Instance.Players[0] != null)
            {
                LevelManager.Instance.KillPlayer(LevelManager.Instance.Players[0]);
            }
        }

        StartCoroutine(startRocket.TriggerRocketStart(player));
    }
}

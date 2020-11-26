using MoreMountains.CorgiEngine;
using UnityEngine;

public class ActivateElevator : MonoBehaviour
{
    public CountdownTimer countDown;

    private bool PlayerOneOnElevator = false;
    private bool PlayerTwoOnElevator = false;
    private MovingPlatform Platform;
    private bool PlatformStarted;

    private void Start()
    {
        Platform = GetComponent<MovingPlatform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        var allPlayersAlive = LevelManager.Instance.Players.Count == 2;

        if (collision.transform.name.Contains("Player1"))
        {
            PlayerOneOnElevator = true;
        }

        if (collision.transform.name.Contains("Player2"))
        {
            PlayerTwoOnElevator = true;
        }

        if (allPlayersAlive)
        {
            if (PlayerOneOnElevator && PlayerTwoOnElevator && !PlatformStarted)
            {
                StartElevator();
            }
        }
        else
        {
            if ((PlayerOneOnElevator || PlayerTwoOnElevator) && !PlatformStarted)
            {
                StartElevator();
            }
        }
    }

    private void StartElevator()
    {
        if (countDown != null)
        {
            countDown.gameObject.SetActive(false);
        }
        Platform.AuthorizeMovement();
        PlatformStarted = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            return;
        }

        if (collision.transform.name.Contains("Player1"))
        {
            PlayerOneOnElevator = false;
        }

        if (collision.transform.name.Contains("Player2"))
        {
            PlayerTwoOnElevator = false;
        }
    }
}

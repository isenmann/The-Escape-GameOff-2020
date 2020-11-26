using MoreMountains.CorgiEngine;
using System.Collections;
using System.Linq;
using UnityEngine;

public class MultiplayerCoopLevelManager : MultiplayerLevelManager
{
	public GameObject[] AvatarHeads;
    protected override void CheckMultiplayerEndGame()
    {
		// both players are dead
		if (Players.All(p => p.ConditionState.CurrentState == CharacterStates.CharacterConditions.Dead))
		{
            DisableAvatarHeads();
			StartCoroutine(GameOver());
		}
	}

	private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(0.5f);

        // if we find a MPGUIManager, we display the game over screen
        if (GUIManager.Instance.GetComponent<MultiplayerGUIManager>() != null)
        {
            GUIManager.Instance.GetComponent<MultiplayerGUIManager>().ShowMultiplayerEndgame();
        }
	}

    public override void KillPlayer(Character player)
    {
        Health characterHealth = player.GetComponent<Health>();
        if (characterHealth == null)
        {
            return;
        }
        else
        {
            // we kill the character
            characterHealth.Kill();
            StartCoroutine(RemovePlayer(player));
            StartCoroutine(SetNewCameraTarget());
        }

        CheckMultiplayerEndGame();
    }

    protected IEnumerator SetNewCameraTarget()
    {
        yield return new WaitForSeconds(0.01f);
        var player = Players.FirstOrDefault();
        if (player != null)
        {
            var cameraController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
            cameraController.SetTarget(player.transform);
            cameraController.TargetController = player.gameObject.GetComponent<CorgiController>();
        }
    }

    private void DisableAvatarHeads()
    {
        foreach (var head in AvatarHeads)
        {
            head.SetActive(false);
        }
    }
}

using CameraUtils;
using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartRocket : MonoBehaviour
{
    public GameObject[] GameObjectsToDeactivate;
    public GameObject[] GameObjectsToActivate;
    private CameraFade Fader;
    private CameraController cameraController;
    public GameObject WinScreen;

    void Start()
    {
        Fader = Camera.main.GetComponent<CameraFade>();
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    public IEnumerator TriggerRocketStart(string player)
    {
        Fader.triggerFade = true;
        LevelManager.Instance.FreezeCharacters();
        yield return new WaitForSeconds(1);
        cameraController.CameraOffset.z -= 10;
        cameraController.enabled = false;
        yield return new WaitForSeconds(1);
        LevelManager.Instance.Players.ForEach(p => p.gameObject.SetActive(false));
        foreach (var gameObject in GameObjectsToDeactivate)
        {
            gameObject.SetActive(false);
        }

        foreach (var gameObject in GameObjectsToActivate)
        {
            gameObject.SetActive(true);
        }

        yield return new WaitForSeconds(1);
        Fader.triggerFade = true;
        GetComponent<MovingPlatform>().AuthorizeMovement();

        yield return new WaitForSeconds(8);

        var textComponent = WinScreen.GetComponentInChildren<Text>();
        textComponent.text = textComponent.text.Replace("%", player);

        WinScreen.SetActive(true);
    }
}

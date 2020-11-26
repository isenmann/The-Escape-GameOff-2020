using MoreMountains.CorgiEngine;
using System.Collections;
using UnityEngine;

public class SetPixelPerfect : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("SetPP");
    }

    private IEnumerator SetPP()
    {
        yield return new WaitForSeconds(2);
        GetComponent<CameraController>().PixelPerfect = true;
    }
}

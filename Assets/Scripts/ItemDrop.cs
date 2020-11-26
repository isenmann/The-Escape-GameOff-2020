/*
Originally taken from https://github.com/reunono/CorgiEngineExtensions
but modified to use it as a feedback component in the CorgiEngine
*/

using MoreMountains.Feedbacks;
using UnityEngine;

[FeedbackPath("GameObject/ItemDrop")]
public class ItemDrop : MMFeedback
{
    public GameObject[] itemDrops;
    public int dropSucessRate = 15;
    public Vector3 SpawnDestination;

    protected override void CustomPlayFeedback(Vector3 position, float attenuation = 1)
    {
        int randomChance = Random.Range(0, 100);

        if (randomChance < dropSucessRate)
        {
            int randomPick = Random.Range(0, itemDrops.Length);
            Instantiate(itemDrops[randomPick], transform.position + SpawnDestination, transform.rotation);
        }
    }
}

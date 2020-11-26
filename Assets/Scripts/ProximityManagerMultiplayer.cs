using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityManagerMultiplayer : ProximityManager
{
    public Transform[] ProximityTargets;

    protected override void SetPlayerAsTarget()
    {
        if (AutomaticallySetPlayerAsTarget)
        {
            ProximityTargets = new Transform[LevelManager.Instance.Players.Count];
            for (int i = 0; i < LevelManager.Instance.Players.Count; i++)
            {
                ProximityTargets[i] = LevelManager.Instance.Players[i].transform;
            }
        }
    }

    protected override void EvaluateDistance()
    {
        if (Time.time - _lastEvaluationAt > EvaluationFrequency)
        {
            _lastEvaluationAt = Time.time;
        }
        else
        {
            return;
        }

        foreach (ProximityManaged proxy in ControlledObjects) 
        {
            float distance = float.MaxValue;

            foreach (var target in ProximityTargets)
            {
                if (target == null)
                {
                    continue;
                }

                float distanceToOtherPlayer = Vector3.Distance(proxy.transform.position, target.position);
                distance = Mathf.Min(distance, distanceToOtherPlayer);
            }

            if (proxy.gameObject.activeInHierarchy && (distance > proxy.DisableDistance))
            {
                StartCoroutine(DelayedDeactivation(proxy));
            }
            if (!proxy.gameObject.activeInHierarchy && proxy.DisabledByManager && (distance < proxy.EnableDistance))
            {
                proxy.DisabledByManager = false;
                proxy.gameObject.SetActive(true);
            }
        }
    }

    IEnumerator DelayedDeactivation(ProximityManaged proxy)
    {
        yield return new WaitForSeconds(1.1f);
        proxy.DisabledByManager = true;
        proxy.gameObject.SetActive(false);
    }
}

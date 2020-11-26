using MoreMountains.CorgiEngine;
using UnityEngine;

public class StartAttackAnimation : MonoBehaviour
{
	private Animator animator;
	private DamageOnTouch damageOnTouch;
	private ProximityManaged proximity;

	protected void Start()
	{
		animator = GetComponentInChildren<Animator>();
		damageOnTouch = GetComponent<DamageOnTouch>();
		proximity = GetComponent<ProximityManaged>();
		if (damageOnTouch != null)
		{
			damageOnTouch.OnHitDamageable += StartAnimation;
		}
	}

    private void StartAnimation()
    {
		animator.SetTrigger("MeleeAttackStart");
    }

    protected void OnDisable()
	{
		if (!proximity.DisabledByManager && damageOnTouch != null)
		{
			damageOnTouch.OnHitDamageable -= StartAnimation;
		}
	}
}

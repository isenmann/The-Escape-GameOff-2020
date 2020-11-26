using MoreMountains.CorgiEngine;
using MoreMountains.InventoryEngine;

public class HealthItem : HealthBonusItem
{
    public override bool Pick()
    {
        return Use();
    }
    public override bool Use()
    {
        var player = TargetInventory.Owner;
        var health = player.GetComponent<Health>();
        health.SetHealth(health.CurrentHealth + HealthBonus, null);
        return true;
    }
}

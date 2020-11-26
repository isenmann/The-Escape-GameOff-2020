using MoreMountains.CorgiEngine;
using MoreMountains.InventoryEngine;
using UnityEngine;

public class WeaponAmmoMultiplayer : WeaponAmmo
{
	public override void OnMMEvent(MMInventoryEvent inventoryEvent)
    {
		FindTargetInventory(inventoryEvent.TargetInventoryName);
		base.OnMMEvent(inventoryEvent);
    }

	public void FindTargetInventory(string targetInventoryName)
	{
		if (targetInventoryName == null)
		{
			return;
		}
		foreach (Inventory inventory in FindObjectsOfType<Inventory>())
		{
			if (inventory.name == targetInventoryName)
			{
				AmmoInventory = inventory;
			}
		}
	}
}

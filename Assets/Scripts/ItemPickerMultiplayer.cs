using MoreMountains.CorgiEngine;
using MoreMountains.InventoryEngine;
using UnityEngine;

public class ItemPickerMultiplayer : ItemPicker
{
    private string targetInventoryName;
    private string targetEquipmentInventoryName;
    private AudioSource audioSource;

    private void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();
    }

    public override void OnTriggerEnter(Collider collider)
    {
        // if what's colliding with the picker ain't a characterBehavior, we do nothing and exit
        if (!collider.CompareTag("Player"))
        {
            return;
        }

        // add the item to the player who collide with the item
        targetInventoryName = collider.gameObject.GetComponent<CharacterInventory>().MainInventoryName;
        targetEquipmentInventoryName = collider.gameObject.GetComponent<CharacterInventory>().WeaponInventoryName;
        SoundManager.Instance.PlaySound(audioSource.clip, transform.position, false);
        Pick(targetInventoryName);
    }

    public override void OnTriggerEnter2D(Collider2D collider)
    {
        // if what's colliding with the picker ain't a characterBehavior, we do nothing and exit
        if (!collider.CompareTag("Player"))
        {
            return;
        }

        // add the item to the player who collide with the item
        targetInventoryName = collider.gameObject.GetComponent<CharacterInventory>().MainInventoryName;
        targetEquipmentInventoryName = collider.gameObject.GetComponent<CharacterInventory>().WeaponInventoryName;
        SoundManager.Instance.PlaySound(audioSource.clip, transform.position, false);
        Pick(targetInventoryName);
    }

    public override void Pick(string targetInventoryName)
    {
        Item.TargetInventoryName = targetInventoryName;
        Item.TargetEquipmentInventoryName = targetEquipmentInventoryName;
       
        base.Pick(targetInventoryName);
    }

    public bool Pickable(string inventoryName)
    {
        FindTargetInventory(inventoryName);

        if (!PickableIfInventoryIsFull && _targetInventory.NumberOfFreeSlots == 0)
        {
            return false;
        }

        return true;
    }
}

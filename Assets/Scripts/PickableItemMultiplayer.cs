using MoreMountains.CorgiEngine;

public class PickableItemMultiplayer : PickableItem
{
    private ItemPickerMultiplayer _itemPickerMultiplayer;

    protected override void Start()
    {
        base.Start();
		_itemPickerMultiplayer = gameObject.GetComponent<ItemPickerMultiplayer>();
	}

    protected override bool CheckIfPickable()
    {
		_character = _pickingCollider.GetComponent<Character>();
		if (_character == null)
		{
			return false;
		}
		if (_character.CharacterType != Character.CharacterTypes.Player)
		{
			return false;
		}
		if (_itemPickerMultiplayer != null)
		{
			if (!_itemPickerMultiplayer.Pickable(_pickingCollider.GetComponent<CharacterInventory>().MainInventoryName))
			{
				return false;
			}
		}

		return true;
	}
}

namespace PixelAdventure
{
    public class GearItem : Item
    {
        private void Awake()
        {
            ItemModel.itemName = Values.GEAR;
            ItemModel.isQuestItem = true;
            ItemModel.isEquipableItem = false;
        }
    }
}

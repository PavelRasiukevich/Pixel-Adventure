namespace PixelAdventure
{
    public class FeatherItem : Item
    {
        private void Awake()
        {
            ItemModel.itemAbilityName = Values.DOUBLEJUMP;
        }
    }
}

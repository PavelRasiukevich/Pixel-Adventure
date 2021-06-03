namespace PixelAdventure
{
    public class GravityBoots : Item
    {
        private void Awake()
        {
            ItemModel.itemAbilityName = Values.FASTFALL;
        }
    }
}

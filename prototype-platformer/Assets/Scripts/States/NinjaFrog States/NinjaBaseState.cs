using PixelAdventure.Interfaces;

namespace PixelAdventure
{
    public abstract class NinjaBaseState
    {
        public abstract void EntryState(NinjaFrogController frog);

        public abstract void Update(NinjaFrogController frog);

        public abstract void FixedUpdate(NinjaFrogController frog);

    }
}

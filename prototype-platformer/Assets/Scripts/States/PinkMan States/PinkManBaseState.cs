namespace PixelAdventure
{
    public abstract class PinkManBaseState
    {
        public abstract void EntryState(PinkManController pink);

        public abstract void Update(PinkManController pink);

        public abstract void FixedUpdate(PinkManController pink);

    }
}

namespace PixelAdventure
{
    public enum LevelState
    {
        Locked,
        Unlocked
    }

    public enum CharacterState
    {
        Idle,
        Move,
        Jump,
        Fall,
        FastFall,
        DoubleJump,
        WallJump,
        Dash,
        Float,
        Die,
        WaterFloat
    }

    public enum DoorState
    {
        Closed,
        Open
    }

    public enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }

    public enum LevelID
    {
        InitialDungeon,
        Dungeon_1,
        Dungeon_2,
        Dungeon_3,
        Cave,
        Castle,
        Tower,
        Forest
    }
}

namespace PixelAdventure
{
    public enum CheckPointState
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
        WaterFloat,
        TrampolineJump,
        Dialog
    }

    public enum BatState
    {
        Idle,
        Chasing,
        CeillingIn,
        CeillingOut
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

    public enum PowerUpStates
    {
        Avaliable,
        Consumed
    }

    public enum ItemState
    {
        Avaliable,
        Picked
    }

    public enum CameraTriggers
    {
        Left_Height,
        Right_Height,
        Bottom_Lenght,
        Up_Lenght
    }
}

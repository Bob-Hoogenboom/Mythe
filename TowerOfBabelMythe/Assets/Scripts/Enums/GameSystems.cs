namespace GameSystems
{
    public enum Levels
    {
        MainMenu,
        level1Platforming,
        level1Combat,
        level2Platforming,
        level2Combat,
        level3Platforming,
        level3Combat
    }

    public enum LevelType
    {
        Menu,
        Platformer,
        Combat
    }

    public enum GameState
    {
        MainMenu,
        Paused,
        Loading,
        Playing
    }
}
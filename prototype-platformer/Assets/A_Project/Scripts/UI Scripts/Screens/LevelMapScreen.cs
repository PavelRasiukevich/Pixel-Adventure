using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PixelAdventure
{
    public class LevelMapScreen : BaseScreen
    {
        public const string EXIT_TO_BACK_SCREEN = "EXIT_TO_BACK_SCREEN";
        public const string EXIT_TO_INITIAL_DUNGEON = "EXIT_TO_INITIAL_DUNGEON";
        public const string EXIT_TO_DUNGEON_1 = "EXIT_TO_DUNGEON_1";
        public const string EXIT_TO_DUNGEON_2 = "EXIT_TO_DUNGEON_2";
        public const string EXIT_TO_DUNGEON_3 = "EXIT_TO_DUNGEON_3";
        public const string EXIT_TO_CAVE = "EXIT_TO_CAVE";
        public const string EXIT_TO_CASTLE = "EXIT_TO_CASTLE";
        public const string EXIT_TO_TOWER = "EXIT_TO_TOWER";
        public const string EXIT_TO_FOREST = "EXIT_TO_FOREST";

        public void OnBackPressed()
        {
            Exit(EXIT_TO_BACK_SCREEN);
        }

        public void OnLevel1Pressed()
        {
            Exit(EXIT_TO_INITIAL_DUNGEON);
        }

        public void OnLevel2Pressed()
        {
            Exit(EXIT_TO_DUNGEON_1);
        }

        public void OnLevel3Pressed()
        {
            Exit(EXIT_TO_DUNGEON_2);
        }

        public void OnLevel4Pressed()
        {
            Exit(EXIT_TO_DUNGEON_3);
        }

        public void OnLevel5Pressed()
        {
            Exit(EXIT_TO_CAVE);
        }

        public void OnLevel6Pressed()
        {
            Exit(EXIT_TO_FOREST);
        }

        public void OnLevel7Pressed()
        {
            Exit(EXIT_TO_CASTLE);
        }

        public void OnLevel8Pressed()
        {
            Exit(EXIT_TO_TOWER);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{

    public class GameOverUIManager : MonoBehaviour
    {
        /// <summary>
        /// The name of the Game.unity scene, as shown in the build screen.
        /// </summary>
        private const string GAME_SCENE_NAME = "Scenes/Game";
        private const string MAIN_MENU_SCENE_NAME = "Scenes/Main Menu";

        public void RetryButton_OnClick()
        {
            SceneManager.LoadScene(GAME_SCENE_NAME);
        }

        public void MainMenuButton_OnClick()
        {
            SceneManager.LoadScene(MAIN_MENU_SCENE_NAME);
        }
    }

}
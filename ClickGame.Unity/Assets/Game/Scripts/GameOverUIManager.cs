using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{

    public class GameOverUIManager : MonoBehaviour
    {
        /// <summary>
        /// The UI element containing the text where state information is displayed
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI scoreText;

        /// <summary>
        /// The name of the Game.unity scene, as shown in the build screen.
        /// </summary>
        private const string GAME_SCENE_NAME = "Scenes/Game";
        private const string MAIN_MENU_SCENE_NAME = "Scenes/Main Menu";

        private int score;

        /// <summary>
        /// Public facing variable to receive the score and update the UI
        /// </summary>
        public int Score
        {
            get => score;
            set
            {
                var newValue = value;
                this.scoreText.text = $"Score: {newValue}";
                this.score = newValue;

            }
        }

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameUI;

        [SerializeField]
        private GameObject gameOverUI;

        private GameManager gameManager;

        //private ScoreManager scoreManager;
        //private UpdatePlayerScore updatePlayerScore;

        public delegate void SwitchToGameOverUIEvent(GameOverUIManager manager);
        /// <summary>
        /// The function to invoke on switch to game over. Transmits state information from the gameUI to the gameOverUI.
        /// </summary>
        public SwitchToGameOverUIEvent OnSwitchToGameOver;

        private void Awake()
        {
            this.gameManager = FindObjectOfType<GameManager>();
            this.gameManager.OnGameOver += SwitchToGameOverUI;
        }

        private void Start()
        {
            this.gameUI.SetActive(true);
        }

        private void SwitchToGameOverUI()
        {
            this.gameUI.SetActive(false);
            this.gameOverUI.SetActive(true);
            var gameOverUIManager = this.gameOverUI.GetComponent<GameOverUIManager>();

            //Make sure the game over UI gets the relevant state information
            this.OnSwitchToGameOver.Invoke(gameOverUIManager);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ScoreManager : MonoBehaviour
    {
        public delegate void ScoreUpdatedEvent(int newValue);
        public ScoreUpdatedEvent OnScoreChanged;

        /// <summary>
        /// A reference to the UI manager in order to transfer the score state between menus
        /// </summary>
        private UIManager uiManager;

        /// <summary>
        /// private player score instance
        /// </summary>
        private int score = 0;

        /// <summary>
        /// Public facing player score
        /// </summary>
        public int Score
        {
            get => score;
            private set {
                this.score = value;
                this.OnScoreChanged?.Invoke(value);
            }
        }

        private void Awake()
        {
            this.uiManager = FindObjectOfType<UIManager>();
            this.uiManager.OnSwitchToGameOver += UpdateGameOverUIScore;
        }

        private void Start()
        {
            this.Score = 0;
        }

        /// <summary>
        /// An event to send the score to the Game Over UI
        /// </summary>
        /// <param name="manager"></param>
        public void UpdateGameOverUIScore(GameOverUIManager manager)
        {
            manager.Score = this.Score;
        }

        /// <summary>
        /// Public facing score manipulation function to apply item click to score, affecting UI.
        /// </summary>
        /// <param name="points"></param>
        /// <remarks>score can be negative</remarks>
        public void AddToScore(int points)
        {
            this.Score += points;
        }
    }
}

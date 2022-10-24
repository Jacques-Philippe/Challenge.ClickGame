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

        private void Start()
        {
            this.Score = 0;
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

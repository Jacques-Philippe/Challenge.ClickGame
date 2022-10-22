using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ScoreManager : MonoBehaviour
    {
        public delegate void ScoreUpdatedEvent(int newValue);
        public ScoreUpdatedEvent OnScoreChanged;

        private int score = 0;

        /// <summary>
        /// Player score
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
        public void AddToScore(int points)
        {
            this.Score += points;
        }
    }
}

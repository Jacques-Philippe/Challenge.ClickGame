using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameManager : MonoBehaviour
    {
        /// <summary>
        /// Whether the game is over
        /// </summary>
        public bool IsGameOver { get; private set; } = false;

        public delegate void GameOverEvent();
        /// <summary>
        /// An event for listeners to subscribe to.
        /// </summary>
        public GameOverEvent OnGameOver;

        public void EndGame()
        {
            this.OnGameOver?.Invoke();
        }
    }
}

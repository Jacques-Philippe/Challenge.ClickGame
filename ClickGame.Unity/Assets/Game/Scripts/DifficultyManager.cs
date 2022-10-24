using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Class responsible for fetching the difficulty information and transmitting it to the relevant components and managers
    /// </summary>
    public class DifficultyManager : MonoBehaviour
    {
        public enum DIFFICULTY { EASY = 0, MEDIUM, HARD};
        DIFFICULTY? currentDifficulty = null;

        public delegate void OnDifficultyFoundEvent(DIFFICULTY difficulty);
        public OnDifficultyFoundEvent OnDifficultyFound;

        private void Awake()
        {
            this.FindDifficulty();

            if (this.currentDifficulty != null)
            {
                this.OnDifficultyFound.Invoke((DIFFICULTY)this.currentDifficulty);
            }
        }

        void FindDifficulty()
        {
            string value = PlayerPrefs.GetString("preference");
            Debug.Log($"Read value {value} for preference");
            switch (value)
            {
                case "easy": this.currentDifficulty = DIFFICULTY.EASY; break;
                case "medium": this.currentDifficulty = DIFFICULTY.MEDIUM; break;
                case "hard": this.currentDifficulty = DIFFICULTY.HARD; break;
                default:
                    {
                        throw new System.Exception("Received unexpected value for FindDifficulty switch");
                    }
            }

        }
    }

}
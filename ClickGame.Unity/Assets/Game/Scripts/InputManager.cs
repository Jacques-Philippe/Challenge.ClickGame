using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class InputManager : MonoBehaviour
    {
        /// <summary>
        /// The currently active input scheme
        /// </summary>
        private Action? inputScheme = null;

        /// <summary>
        /// A reference to our game manager
        /// </summary>
        private GameManager gameManager;

        private void Awake()
        {
            this.gameManager = FindObjectOfType<GameManager>();

            this.gameManager.OnGameOver += ChangeToGameOverInputScheme;
        }

        private void Start()
        {
            this.inputScheme = GameInputScheme;
        }

        // Update is called once per frame
        void Update()
        {
            inputScheme?.Invoke();
        }

        private void ChangeToGameOverInputScheme()
        {
            this.inputScheme = GameInputScheme;
        }

        private void GameInputScheme()
        {
            Debug.Log("Game input scheme");
        }

        private void GameOverInputScheme()
        {
            Debug.Log("Game over input scheme");
        }

    }
}

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
        }
    }
}

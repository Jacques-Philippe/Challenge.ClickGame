using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(AudioSource))]
    public class SoundManager : MonoBehaviour
    {
        [SerializeField]
        private AudioClip gameMusic;

        [SerializeField]
        private AudioClip gameOverMusic;

        private GameManager gameManager;
        private AudioSource audioSource;

        #region UNITY FUNCTIONS
        private void Awake()
        {
            this.gameManager = FindObjectOfType<GameManager>();
            this.audioSource = this.GetComponent<AudioSource>();
        }

        private void Start()
        {
            this.PlayGameMusic();
        }

        private void OnEnable()
        {
            this.gameManager.OnGameOver += PlayGameOverMusic;
        }

        private void OnDisable()
        {
            this.gameManager.OnGameOver -= PlayGameOverMusic;
        }

        #endregion

        private void PlayGameOverMusic()
        {
            this.audioSource.clip = gameOverMusic;
            this.audioSource.loop = true;
            this.audioSource.Play();
        }

        private void PlayGameMusic()
        {
            this.audioSource.clip = gameMusic;
            this.audioSource.loop = true;
            this.audioSource.Play();
        }

    }
}

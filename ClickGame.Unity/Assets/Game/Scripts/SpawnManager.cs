using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{

    public class SpawnManager : MonoBehaviour
    {
        /// <summary>
        /// Our item prefabs, these are made up of both good and bad items
        /// </summary>
        [SerializeField]
        private List<GameObject> itemPrefabs;

        /// <summary>
        /// our reference to our game manager
        /// </summary>
        private GameManager gameManager;

        /// <summary>
        /// The delay before the next enemy is spawned
        /// </summary>
        private float spawnDelay = 1.0f;


        /// <summary>
        /// The minimum X value an item should be spawned at
        /// </summary>
        private const float X_MIN = -5.0f;
        /// <summary>
        /// The maximum X value an item should be spawned at
        /// </summary>
        private const float X_MAX = 5.0f;
        /// <summary>
        /// The Z value an item should be spawned at
        /// </summary>
        private const float Z = -3.46f;
        /// <summary>
        /// The Y value an item should be spawned at
        /// </summary>
        private const float Y = -5.0f;

        private bool shouldStopSpawning = false;

        private void Awake()
        {
            this.gameManager = FindObjectOfType<GameManager>();
            this.gameManager.OnGameOver += StopSpawning;
        }

        private void Start()
        {
            StartCoroutine(Spawn());
        }

        private void StopSpawning()
        {
            this.shouldStopSpawning = true;
        }

        private IEnumerator Spawn()
        {
            yield return new WaitForSeconds(this.spawnDelay);
            int index = Random.Range(0, this.itemPrefabs.Count);
            var prefab = this.itemPrefabs[index];
            float x = Random.Range(X_MIN, X_MAX);
            Vector3 position = new Vector3(x, Y, Z);
            GameObject.Instantiate(prefab, position, new Quaternion());
            if (!shouldStopSpawning)
            {
                yield return Spawn();
            }
            yield return null;
        }
    }
}

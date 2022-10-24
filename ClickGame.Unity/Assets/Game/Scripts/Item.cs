using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Game
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Item : MonoBehaviour
    {
        /// <summary>
        /// The explosion to trigger when the item is clicked
        /// </summary>
        [SerializeField]
        private ParticleSystem particleSystem;
        
        /// <summary>
        /// The amount of points the item is worth
        /// </summary>
        public int points;

        private ScoreManager scoreManager;

        private Rigidbody rigidbody;

        private GameManager gameManager;

        private const float UPWARD_FORCE_MAX = 14;
        private const float UPWARD_FORCE_MIN = 8;

        /// <summary>
        /// The boundary beyond which items cannot fall.
        /// If a good item falls past this boundary, the game is over.
        /// </summary>
        private const float LOWER_BOUNDARY = -5.0f;

        /// <summary>
        /// Whether the item is a "good" or "bad" item. A good item is an item whose score value is positive.
        /// </summary>
        /// <remarks>if a good item falls below the boundary, the game is over, but if a bad item falls below the boundary nothing happens.</remarks>
        [HideInInspector]
        public bool IsGoodItem
        {
            get => points > 0;
        }


        private void Awake()
        {
            this.scoreManager = FindObjectOfType<ScoreManager>();
            this.rigidbody = GetComponent<Rigidbody>();
            this.gameManager = FindObjectOfType<GameManager>();
        }

        private void Start()
        {
            this.ShootUpward();
        }

        private void Update()
        {
            //Destroy the object when it falls below the horizon
            var currentItemHeight = this.transform.position.y;
            bool itemIsBelowLowerBoundary = currentItemHeight <= LOWER_BOUNDARY;
            
            //end the game for a good item fallen below the boundary
            if (itemIsBelowLowerBoundary)
            {
                if (!gameManager.IsGameOver && this.IsGoodItem)
                {
                    gameManager.EndGame();
                }
                GameObject.Destroy(this.gameObject);
            }
        }

        private void OnMouseDown()
        {
            this.scoreManager.AddToScore(points);
            //Spawn and play the particle system at the current item option, creating the illusion that the item explodes
            var particleSystemGameObj = GameObject.Instantiate(this.particleSystem.gameObject, this.transform.position, this.transform.rotation);
            var particleSystem = particleSystemGameObj.GetComponent<ParticleSystem>();
            particleSystem.Play();
            //Destroy the item
            GameObject.Destroy(this.gameObject);
        }

        /// <summary>
        /// A helper function to shoot the item upwards in a parabolic motion on spawn
        /// </summary>
        private void ShootUpward()
        {
            float upwardForce = Random.Range(UPWARD_FORCE_MIN, UPWARD_FORCE_MAX);
            this.rigidbody.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
            float x = Random.Range(0, 10);
            float y = Random.Range(0, 10);
            float z = Random.Range(0, 10);

            Vector3 torque = new Vector3(x, y, z);
            this.rigidbody.AddTorque(torque);
        }
    }
}

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

        private const float UPWARD_FORCE_MAX = 14;
        private const float UPWARD_FORCE_MIN = 8;


        private void Awake()
        {
            this.scoreManager = FindObjectOfType<ScoreManager>();
            this.rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            this.ShootUpward();
        }

        private void OnMouseDown()
        {
            //Debug.Log("OnMouseDown");
            this.scoreManager.AddToScore(points);
            //Spawn and play the particle system
            var particleSystemGameObj = GameObject.Instantiate(this.particleSystem.gameObject, this.transform.position, this.transform.rotation);
            var particleSystem = particleSystemGameObj.GetComponent<ParticleSystem>();
            particleSystem.loop = false;
            particleSystem.Play();
            //Destroy this
            GameObject.Destroy(this.gameObject);
        }

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

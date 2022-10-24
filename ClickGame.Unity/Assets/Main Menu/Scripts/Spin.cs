using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 namespace MainMenu
{

    [RequireComponent(typeof(Transform))]
    public class Spin : MonoBehaviour
    {
        public float speed;

        // Update is called once per frame
        void Update()
        {
            this.transform.Rotate(0, speed * Time.deltaTime, 0);
        }
    }

}
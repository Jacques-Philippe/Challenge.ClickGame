
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace Game
{

    public class UpdatePlayerScore : MonoBehaviour
    {
        /// <summary>
        /// The UI element containing the text where state information is displayed
        /// </summary>
        [SerializeField]
        private TextMeshProUGUI text;

        /// <summary>
        /// The state value contained in the text
        /// </summary>
        private int value;

        /// <summary>
        /// The public-facing accessor and mutator for the value. <br />
        /// </summary>
        /// <remarks>Changing this value will update the UI</remarks>
        public int Value
        {
            get => value;
            set
            {
                this.ThreadsafeUpdate(newValue: value);
                this.value = value;
            }
        }

        private ScoreManager scoreManager;

        /// <summary>
        /// A queue to contain all enqueued text to update the UI with
        /// </summary>
        /// <remarks>this is done so that updates to the UI are made properly</remarks>
        protected ConcurrentQueue<string> mQueuedText = new ConcurrentQueue<string>();

        private void Awake()
        {
            this.scoreManager = FindObjectOfType<ScoreManager>();
            this.scoreManager.OnScoreChanged += (int newValue) =>
            {
                this.Value = newValue;
            };
        }

        private void Update()
        {
            UpdateText();
        }

        void ThreadsafeUpdate(int newValue)
        {
            mQueuedText.Enqueue($"{newValue}");
        }

        protected virtual void UpdateText()
        {
            while (mQueuedText.TryDequeue(out var newValue))
            {
                text.text = $"Score: {newValue}";
            }
        }

    }
}
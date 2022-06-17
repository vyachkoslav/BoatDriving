using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class Point : MonoBehaviour
    {
        private const string k_playerTag = "Ship";
        public bool Triggered { get; private set; }

        public delegate void TriggerDelegate();
        public TriggerDelegate OnTrigger;

        private void OnTriggerEnter(Collider other)
        {
            if (!Triggered)
            {
                if (other.attachedRigidbody.CompareTag(k_playerTag))
                {
                    Triggered = true;
                    OnTrigger?.Invoke();
                }
            }
        }
    }
}
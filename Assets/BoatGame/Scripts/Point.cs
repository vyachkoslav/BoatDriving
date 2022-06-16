using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class Point : MonoBehaviour
    {
        private const string k_playerTag = "Ship";
        public bool Triggered { get; private set; }

        private void OnTriggerEnter(Collider other)
        {
            if (other.attachedRigidbody.CompareTag(k_playerTag))
                Triggered = true;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public abstract class Objective : ScriptableObject
    {
        [SerializeField] private string description;
        public string Description => description;

        public delegate void ChangingStateDelegate();
        public ChangingStateDelegate OnDone, OnFailed;

        public abstract void Start();
        public abstract bool IsDone();
        public abstract bool IsFailed();
    }
}
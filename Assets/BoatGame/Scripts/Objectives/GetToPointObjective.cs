using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    [CreateAssetMenu(fileName = "New Get To Point Objective", menuName = "ScriptableObjects/Objectives/Get To Point Objective", order = 1)]
    public class GetToPointObjective : Objective
    {
        [SerializeField] string pointTag;
        bool done;
        public override void Start()
        {
            done = false;
            GameObject namedObject = GameObject.FindGameObjectWithTag(pointTag);
            Point pointComponent = namedObject.GetComponent<Point>();
            if (!pointComponent)
                pointComponent = namedObject.AddComponent<Point>();

            pointComponent.OnTrigger += SetDone;
        }
        public override bool IsDone()
        {
            return done;
        }
        public override bool IsFailed()
        {
            return false;
        }
        void SetDone()
        {
            if (!done)
            {
                done = true;
                OnDone?.Invoke();
            }
        }
    }
}
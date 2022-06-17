using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    [CreateAssetMenu(fileName = "New Don't Touch Point Objective", menuName = "ScriptableObjects/Objectives/Don't Touch Point Objective", order = 2)]
    public class DontTouchPointObjective : Objective
    {
        [SerializeField] string pointTag;
        List<Point> points = new List<Point>();
        bool failed = false;

        public override void Start()
        {
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(pointTag);
            
            foreach(GameObject obj in taggedObjects)
            {
                Point pointComponent = obj.GetComponent<Point>();
                if (!pointComponent)
                    pointComponent = obj.AddComponent<Point>();

                pointComponent.OnTrigger += SetFailed;
                points.Add(pointComponent);
            }
        }
        public override bool IsDone()
        {
            return false;
        }

        public override bool IsFailed()
        {
            return failed;
        }

        void SetFailed()
        {
            failed = true;
            OnFailed?.Invoke();
        }
    }
}
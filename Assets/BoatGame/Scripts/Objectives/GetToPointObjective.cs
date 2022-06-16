using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    [CreateAssetMenu(fileName = "New Get To Point Objective", menuName = "ScriptableObjects/Objectives/Get To Point Objective", order = 1)]
    public class GetToPointObjective : Objective
    {
        [SerializeField] string pointTag;
        Point point;
        public override void Start()
        {
            GameObject namedObject = GameObject.FindGameObjectWithTag(pointTag);
            Point pointComponent = namedObject.GetComponent<Point>();
            if (pointComponent)
                point = pointComponent;
            else
                point = namedObject.AddComponent<Point>();
        }
        public override bool IsDone()
        {
            if (point)
                return point.Triggered;
            return false;
        }
        public override bool IsFailed()
        {
            return false;
        }
    }
}
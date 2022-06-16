using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    [CreateAssetMenu(fileName = "New Don't Touch Point Objective", menuName = "ScriptableObjects/Objectives/Don't Touch Point Objective", order = 2)]
    public class DontTouchPointObjective : Objective
    {
        [SerializeField] string pointTag;
        List<Point> points;
        public override void Start()
        {
            points.Clear();
            GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(pointTag);
            
            foreach(GameObject obj in taggedObjects)
            {
                Point pointComponent = obj.GetComponent<Point>();
                if (pointComponent)
                    points.Add(pointComponent);
                else
                    points.Add(obj.AddComponent<Point>());
            }
        }
        public override bool IsDone()
        {
            return false;
        }

        public override bool IsFailed()
        {
            foreach(Point point in points)
            {
                if (point.Triggered)
                    return true;
            }
            return false;
        }
    }
}
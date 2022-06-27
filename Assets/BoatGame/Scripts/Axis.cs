using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BoatGame
{
    public class Axis : MonoBehaviour
    {
        public Vector3 Up => transform.up;
        public Vector3 Right => transform.right;
        public Vector3 Forward => transform.forward;
        public Vector3 Center => transform.position;

        public void Rotate(float angle)
        {
            transform.Rotate(Vector3.forward * angle);
        }
        public float GetAngle()
        {
            return transform.localEulerAngles.z;
        }
        public Vector3 ClosestPointOnAxis(Vector3 pos)
        {
            Plane plane = new Plane(Up + Center, Right + Center, Center);
            return plane.ClosestPointOnPlane(pos);
        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, new Vector3(1, 1, 0));
            Gizmos.color = new Color(0, 0, 1, 0.5f);
            Gizmos.DrawSphere(Vector3.zero, 1f);
        }


        static GameObject CreateAxis()
        {
            GameObject objectTemplate = new GameObject("Axis");
            objectTemplate.AddComponent<Axis>();
            return objectTemplate;
        }

        [MenuItem("GameObject/BoatGame/Axis")]
        public static void Create(MenuCommand menuCommand)
        {
            GameObject newObject = CreateAxis();
            GameObjectUtility.SetParentAndAlign(newObject, menuCommand.context as GameObject);
            Undo.RegisterCreatedObjectUndo(newObject, "Create " + newObject.name);
            Selection.activeObject = newObject;
        }
    }
}
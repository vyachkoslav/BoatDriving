using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace BoatGame
{
    public class VRObjectGrabber : MonoBehaviour
    {
        static List<RotatableObject> grabbedObjects = new List<RotatableObject>();

        XRController controller;
        RotatableObject selectedObject;
        RotatableObject grabbedObject;
        private void Start()
        {
            controller = GetComponentInParent<XRController>();
        }
        void Update()
        {
            if (InputProvider.Select(controller) > 0.9)
            {
                if (selectedObject && !grabbedObject)
                {
                    GrabObject();
                }

                if (grabbedObject)
                {
                    grabbedObject.SetPosition(transform.position);
                }
            }
            else
            {
                Drop();
            }
        }
        void OnTriggerStay(Collider other)
        {
            RotatableObject grabbable;
            if (!other.TryGetComponent(out grabbable))
                grabbable = other.GetComponentInParent<RotatableObject>();

            if (selectedObject && grabbable && selectedObject != grabbable) // if new is nearer then old
            {
                float distanceToSelected = Vector3.Distance(transform.position, selectedObject.transform.position);
                float distanceToGrabbable = Vector3.Distance(transform.position, grabbable.transform.position);
                if (distanceToSelected > distanceToGrabbable)
                {
                    selectedObject = grabbable;
                }
            }
            else if (grabbable)
                selectedObject = grabbable;
        }
        void GrabObject()
        {
            if (grabbedObjects.Contains(selectedObject))
                return;
            if (selectedObject)
            { 
                grabbedObject = selectedObject;
                grabbedObjects.Add(selectedObject);
            }
        }
        void Drop()
        {
            grabbedObjects.Remove(grabbedObject);
            grabbedObject = null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace BoatGame
{
    public class VRObjectGrabber : MonoBehaviour
    {
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
            RotatableObject grabbable = other.GetComponent<RotatableObject>();
            if (!grabbable)
                grabbable = other.GetComponentInParent<RotatableObject>();
            if (grabbable)
                selectedObject = grabbable;
        }
        void GrabObject()
        {
            if (selectedObject)
                grabbedObject = selectedObject;
        }
        void Drop()
        {
            grabbedObject = null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class VRObjectGrabber : MonoBehaviour
    {
        RotatableObject selectedObject;
        RotatableObject grabbedObject;
        void Update()
        {
            if (grabbedObject)
            {
                grabbedObject.SetPosition(transform.position);
            }
            else
            {
                GrabObject();
            }
            
        }
        void OnTriggerEnter(Collider other)
        {
            RotatableObject grabbable = other.GetComponent<RotatableObject>();
            if (grabbable)
            {
                selectedObject = grabbable;
            }
        }
        void GrabObject()
        {
            if (selectedObject)
            {
                grabbedObject = selectedObject;
            }
        }
    }
}
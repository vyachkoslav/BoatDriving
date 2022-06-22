using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class VRObjectGrabber : MonoBehaviour
    {
        GrabbableObject selectedObject;
        GrabbableObject grabbedObject;
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
            GrabbableObject grabbable = other.GetComponent<GrabbableObject>();
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
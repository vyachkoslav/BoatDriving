using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class ObjectFollower : MonoBehaviour
    {
        [SerializeField] Transform objectToFollow;
        Vector3 offset;

        void Start()
        {
            if (objectToFollow)
                offset = transform.position - objectToFollow.position;
        }
        void Update()
        {
            if (objectToFollow)
                transform.position = objectToFollow.position + offset;
        }
    }
}
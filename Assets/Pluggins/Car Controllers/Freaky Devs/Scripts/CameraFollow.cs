using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CameraControlsforcar
{
    public class CameraFollow : MonoBehaviour
    {
        public float moveSmoothness;
        public float rotSmoothness;

        public Vector3 moveOffset;
        public Vector3 rotOffset;

        public Transform carTarget;

        void FixedUpdate()
        {
            FollowTarget();
        }

        void FollowTarget()
        {
            HandleMovement();
            HandleRotation();
        }

        void HandleMovement()
        {
            Vector3 targetPos = carTarget.TransformPoint(moveOffset);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSmoothness * Time.deltaTime);
        }

        void HandleRotation()
        {
            Vector3 direction = carTarget.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(direction + rotOffset, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotSmoothness * Time.deltaTime);
        }
    }
}
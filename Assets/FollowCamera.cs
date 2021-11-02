using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject cameraTarget;
    [SerializeField] Vector3 cameraOffset;

    void LateUpdate() {
        {
            transform.position = cameraTarget.transform.position + cameraOffset;
        }
    }
}

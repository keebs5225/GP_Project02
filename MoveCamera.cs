using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPostition;
    private void Update()
    {
        transform.position = cameraPostition.position;
    }
}

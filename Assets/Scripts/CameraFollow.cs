using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 Offset;
    public Transform MyPlay;

    public void Update()
    {
        transform.position = MyPlay.position + Offset;
    }
}

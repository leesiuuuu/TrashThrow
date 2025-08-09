using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform[] transforms;
    void Start()
    {
        transform.position = transforms[0].position;
    }

}

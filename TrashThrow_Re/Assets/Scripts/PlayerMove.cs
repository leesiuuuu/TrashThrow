using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Transform[] transforms;

    void Start()
    {
        
    }
    public void MovePos(int n)
    {
        transform.position = transforms[n].position;
    }
}

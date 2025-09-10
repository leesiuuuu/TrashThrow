using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITeleporter : MonoBehaviour
{
    public Transform[] MapPos;

    public void MovePos(int i)
    {
        transform.position = MapPos[i].position;
    }
}

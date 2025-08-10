using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Locomotion.Teleportation;

public class FloorCollider : MonoBehaviour
{
    private TeleportationArea area;

    void Start()
    {
        area = GetComponent<TeleportationArea>();
        area.colliders.Add(GetComponent<Collider>());
    }

}

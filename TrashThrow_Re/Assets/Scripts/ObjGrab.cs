using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ObjGrab : MonoBehaviour
{
    private XRGrabInteractable xRGrabInteractable;

    void Start()
    {
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
        xRGrabInteractable.colliders.Add(GetComponent<Collider>());
    }
}

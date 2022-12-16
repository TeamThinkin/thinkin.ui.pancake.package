using System.Collections;
using UnityEngine;


public class Grabbable : MonoBehaviour, IGrabbable, IHandlePointerEvent
{
    public event IGrabbable.GrabEventDelegate OnBeforeGrab;
    public event IGrabbable.GrabEventDelegate OnGrab;
    public event IGrabbable.GrabEventDelegate OnRelease;

    private GameObject trackingAnchor;
    private IUIPointer trackingPointer;
    private float rayLength;
    private Vector3 rayLocalOffset;

    private void Update()
    {
        if(trackingAnchor != null)
        {
            transform.rotation = trackingAnchor.transform.rotation;

            var localRayPoint = trackingPointer.transform.InverseTransformPoint(trackingPointer.Ray.origin + (trackingPointer.Ray.direction * rayLength));
            localRayPoint += rayLocalOffset;
            transform.position = trackingPointer.transform.TransformPoint(localRayPoint);
        }
    }

    public void OnGripEnd(IUIPointer Sender)
    {
    } 

    public void OnGripStart(IUIPointer Sender, RaycastHit RayInfo)
    {
    }

    public void OnHoverEnd(IUIPointer Sender)
    {
        
    }

    public void OnHoverStart(IUIPointer Sender, RaycastHit RayInfo)
    {
    }

    public void OnTriggerEnd(IUIPointer Sender)
    {
        if (trackingAnchor == null) return;
        Destroy(trackingAnchor);
        trackingAnchor = null;
        trackingPointer = null;
        OnRelease?.Invoke(null, this);
    }

    public void OnTriggerStart(IUIPointer Sender, RaycastHit RayInfo)
    {
        OnBeforeGrab?.Invoke(null, this);

        if (trackingAnchor == null)
        {
            trackingAnchor = new GameObject("Grabbable Tracking Anchor (" + gameObject.name + ")");
        }

        trackingPointer = Sender;

        trackingAnchor.transform.position = transform.position;
        trackingAnchor.transform.rotation = transform.rotation;
        trackingAnchor.transform.localScale = transform.localScale;

        trackingAnchor.transform.SetParent(Sender.transform, true);

        rayLength = (RayInfo.point - Sender.Ray.origin).magnitude;
        rayLocalOffset = trackingPointer.transform.InverseTransformPoint(transform.position - RayInfo.point + trackingPointer.transform.position);

        OnGrab?.Invoke(null, this);
    }
}

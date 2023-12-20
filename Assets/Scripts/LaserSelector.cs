using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LaserSelector : MonoBehaviour
{
    public Material laserMaterial;
    public LineRenderer lineRenderer;
    public float raycastDistance = 10f;
    public enum Hand { LEFT, RIGHT };
    public Hand hand = Hand.RIGHT;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.material = laserMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        //Update Line Renderer Position
        Ray ray = new Ray(transform.position, transform.forward);
        lineRenderer.SetPosition(0, transform.position);
        Vector3 endPosition = transform.position + transform.forward * raycastDistance;
        lineRenderer.SetPosition(1, endPosition);

        // Raycast to detect UI elements
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycastDistance))
        {
            // Check if the hit object is a UI element
            if (hit.collider.tag == "Pressable")
            {
                if ((hand == Hand.RIGHT && OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger) > 0.9f) ||
                    (hand == Hand.LEFT && OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > 0.9f))
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
    }
}
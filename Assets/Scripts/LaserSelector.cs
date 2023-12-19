using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSelector : MonoBehaviour
{
    public Material laserMaterial;
    public Material indicationMaterial;

    private LineRenderer lineRenderer;
    private GameObject indicatedGameObject = null;
    private Material tmpMaterial;

    public enum Hand { LEFT, RIGHT };
    public Hand hand = Hand.RIGHT;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.material = laserMaterial;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayEnd = transform.position + transform.forward * 100f;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            rayEnd = hit.point;

            if (hit.collider.tag == "Pressable")
            {
                Renderer renderer = hit.collider.gameObject.GetComponent<Renderer>();

                if (indicatedGameObject == null)
                {
                    tmpMaterial = renderer.material;
                    renderer.material = indicationMaterial;
                    indicatedGameObject = hit.collider.gameObject;
                }
            }
        }
        else if (indicatedGameObject != null)
        {
            indicatedGameObject.GetComponent<Renderer>().material = tmpMaterial;
            indicatedGameObject = null;
        }

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, rayEnd);
    }
}
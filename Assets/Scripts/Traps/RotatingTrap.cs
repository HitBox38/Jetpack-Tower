using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingTrap : MonoBehaviour
{
    [SerializeField] private float rotationSpeedFactor = 10f;
    private Vector3 center;
    private float rotationSpeed;

    void Start()
    {
        // Calculate the center and size of the object based on its children
        Bounds combinedBounds = new Bounds();
        int childCount = 0;

        foreach (Transform childTransform in transform)
        {
            Renderer childRenderer = childTransform.GetComponent<Renderer>();
            if (childRenderer != null)
            {
                if (childCount == 0)
                {
                    combinedBounds = childRenderer.bounds;
                }
                else
                {
                    combinedBounds.Encapsulate(childRenderer.bounds);
                }
                childCount++;
            }
        }

        if (childCount > 0)
        {
            // Calculate the center and rotation speed based on the combined bounds
            center = combinedBounds.center;
            rotationSpeed = combinedBounds.size.magnitude * rotationSpeedFactor;
        }
    }

    void Update()
    {
        // Rotate the object around its center and Z axis
        transform.RotateAround(center, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}

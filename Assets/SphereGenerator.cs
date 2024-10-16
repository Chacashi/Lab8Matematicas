using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGenerator : MonoBehaviour
{
    public Color gizmoColor = Color.red; 
    public float radius = 1f; 
    public int totalVertices = 256; 
    private int latitudeSegments;
    private int longitudeSegments;

    void Update()
    {
      
        int sqrtVertices = Mathf.FloorToInt(Mathf.Sqrt(totalVertices));
        latitudeSegments = sqrtVertices - 1; 
        longitudeSegments = sqrtVertices - 1; 
    }

    void OnDrawGizmos()
    {
        Gizmos.color = gizmoColor;

        
        for (int lat = 0; lat <= latitudeSegments; lat++)
        {
            float theta = lat * Mathf.PI / latitudeSegments; 
            float sinTheta = Mathf.Sin(theta);
            float cosTheta = Mathf.Cos(theta);

            for (int lon = 0; lon <= longitudeSegments; lon++)
            {
                float phi = lon * 2 * Mathf.PI / longitudeSegments; 
                float sinPhi = Mathf.Sin(phi);
                float cosPhi = Mathf.Cos(phi);

               
                Vector3 point = new Vector3(
                    radius * sinTheta * cosPhi,
                    radius * cosTheta,
                    radius * sinTheta * sinPhi
                );

            
                if (lat > 0 && lon > 0)
                {
                    Gizmos.DrawLine(transform.position + point, transform.position + point);
                }

               
                if (lat < latitudeSegments)
                {
                    Vector3 nextPoint = new Vector3(
                        radius * Mathf.Sin((lat + 1) * Mathf.PI / latitudeSegments) * cosPhi,
                        radius * Mathf.Cos((lat + 1) * Mathf.PI / latitudeSegments),
                        radius * Mathf.Sin((lat + 1) * Mathf.PI / latitudeSegments) * sinPhi
                    );

                    Gizmos.DrawLine(transform.position + point, transform.position + nextPoint);
                }

               
                if (lon < longitudeSegments)
                {
                    Vector3 nextPoint = new Vector3(
                        radius * sinTheta * Mathf.Cos((lon + 1) * 2 * Mathf.PI / longitudeSegments),
                        radius * cosTheta,
                        radius * sinTheta * Mathf.Sin((lon + 1) * 2 * Mathf.PI / longitudeSegments)
                    );

                    Gizmos.DrawLine(transform.position + point, transform.position + nextPoint);
                }
            }
        }
    }
}



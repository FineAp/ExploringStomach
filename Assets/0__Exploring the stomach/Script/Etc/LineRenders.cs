using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRenders : MonoBehaviour
{
    public Transform startPoint; // 레이 시작점
    public float rayDistance = 10f; // 레이 거리
    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }

    void Update()
    {
        // 레이 발사
        RaycastHit hit;
        if (Physics.Raycast(startPoint.position, startPoint.forward, out hit, rayDistance))
        {
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, hit.point);
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
        }
        else
        {
            lineRenderer.SetPosition(0, startPoint.position);
            lineRenderer.SetPosition(1, startPoint.position + startPoint.forward * rayDistance);
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
        }
    }
}
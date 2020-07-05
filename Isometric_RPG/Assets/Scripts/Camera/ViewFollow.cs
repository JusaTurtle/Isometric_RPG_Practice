using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFollow : MonoBehaviour
{
    public Transform target;
    public Transform view;
    public Vector3 offSet;
    public float smoothSpeed;
    public LayerMask whatIsWall;
    private Renderer prevWall;

    private void Update()
    {
        view.position = Vector3.Lerp(view.position, target.position + offSet, smoothSpeed * Time.deltaTime);
        Ray ray = new Ray(view.position, target.position - view.position);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, whatIsWall, QueryTriggerInteraction.Ignore))
        {
            prevWall = hitInfo.collider.GetComponent<MeshRenderer>();
            prevWall.enabled = false;
        }
        else
        {
            prevWall.enabled = true;
        }
    }
}

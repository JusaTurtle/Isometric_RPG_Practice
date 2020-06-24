using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewFollow : MonoBehaviour
{
    public Transform target;
    public Transform view;
    public Vector3 offSet;
    public float smoothSpeed;

    private void Update() {
        view.position = Vector3.Lerp(view.position, target.position + offSet, smoothSpeed * Time.deltaTime);
    }
}

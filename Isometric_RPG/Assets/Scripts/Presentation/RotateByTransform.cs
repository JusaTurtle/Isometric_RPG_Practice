using UnityEngine;

public class DefaultTransform : Transformable
{
    private Transform body;

    public DefaultTransform(Transform body)
    {
        this.body = body;
    }

    public Vector3 GetPos()
    {
        return body.position;
    }

    public float GetRotDeg()
    {
        return body.eulerAngles.y;
    }

    public void Rotate(float deg)
    {
        body.Rotate(Vector3.up * deg);
    }

    public void RotateTo(float deg)
    {
        body.eulerAngles = new Vector3(0, deg, 0);
    }
}
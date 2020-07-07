using UnityEngine;

public interface Transformable
{
    void RotateTo(float deg);
    void Rotate(float deg);
    float GetRotDeg();
    Vector3 GetPos();
}
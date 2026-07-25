using UnityEngine;

public class Rotator : MonoBehaviour
{
    // A protected function allows the child of the class to call the function
    protected void LookAt(Vector3 target)
    {
        // Calculate the angle between Transform and Target
        // Add 90° to make sure Look Angle is actually pointing to the target, since Unity defaults objects to
        // look to the right, we correct the offset with this
        float lookAngle = AngleBetweenTwoPoints(transform.position, target) + 90;
        
        // Assign the target rotation on the Z Axis
        transform.eulerAngles = new Vector3(0, 0, lookAngle);
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}

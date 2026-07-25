using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class PlayerRotation : Rotator
{
    // Determine the Mouse Position and Look There

    private void OnLook(InputValue value)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(value.Get<Vector2>());
        LookAt(mousePosition);
    }
     
}

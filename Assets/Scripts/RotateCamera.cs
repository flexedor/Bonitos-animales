using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float speed = 0.1f;
    public float minY = -60f;
    public float maxY = 60f;
    public float minX = -60f;
    public float maxX = 60f;
    public float swipeThreshold = 50f;

    Vector2 startTouchPosition;
    Vector3 currentRotation;

    bool isSwiping = false;

    void Start()
    {
        currentRotation = transform.rotation.eulerAngles;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isSwiping = true;
                startTouchPosition = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
            {
                isSwiping = false;
            }
        }

        // Calculate swipeDelta only if the touch moved beyond the threshold
        if (isSwiping && (Input.touches[0].position - startTouchPosition).magnitude > swipeThreshold)
        {
            Vector2 swipeDelta = Input.touches[0].position - startTouchPosition;

            // Calculate new rotation and clamp it
            currentRotation.y -= swipeDelta.x * speed;
            currentRotation.y = Mathf.Clamp(currentRotation.y, minX, maxX);
            currentRotation.x += swipeDelta.y * speed;
            currentRotation.x = Mathf.Clamp(currentRotation.x, minY, maxY);

            // Apply rotation
            transform.rotation = Quaternion.Euler(currentRotation);

            // Update the startTouchPosition for the next frame
            startTouchPosition = Input.touches[0].position;
        }
    }

    public void SetCustomRotation(Vector3 newRotation)
    {
        currentRotation = newRotation;
        transform.rotation = Quaternion.Euler(newRotation);
    }
}

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

    Vector2 startTouchPosition, swipeDelta;
    Vector3 currentRotation;
    private GameController _gameController;

    bool isSwiping = false;

    void Start()
    {
        currentRotation = transform.eulerAngles;
        _gameController = FindObjectOfType<GameController>();
    }

    void Update()
    {
        if (_gameController._curretStageState == GameController.StageState.Resquing) return;

        if (Input.touchCount > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                isSwiping = true;
                startTouchPosition = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Canceled || Input.touches[0].phase == TouchPhase.Ended)
            {
                Reset();
            }
        }

        // Calculating swipeDelta
        swipeDelta = Vector2.zero;
        if (isSwiping)
        {
            if (Input.touchCount > 0)
            {
                swipeDelta = Input.touches[0].position - startTouchPosition;
            }
        }

        // Did we cross the deadzone?
        if (swipeDelta.magnitude > 125)
        {
            // Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;

            // Calculate new rotation and clamp it
            currentRotation.y -= x * speed;
            currentRotation.y = Mathf.Clamp(currentRotation.y, minX, maxX);
            currentRotation.x += y * speed;
            currentRotation.x = Mathf.Clamp(currentRotation.x, minY, maxY);

            // Apply rotation
            transform.rotation = Quaternion.Euler(currentRotation);
        }
    }

    private void Reset()
    {
        startTouchPosition = swipeDelta = Vector2.zero;
        isSwiping = false;
    }
    public void SetCustomRotation(Vector3 newRotation)
    {
        currentRotation = newRotation;
        transform.rotation = Quaternion.Euler(newRotation);
    }
}

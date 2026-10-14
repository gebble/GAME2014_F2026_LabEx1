using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBehavior : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private Boundary horizontalBoundary = new Boundary { min = -2.0f, max = 2.0f };

    private Camera mainCamera;
    private Vector2 destination;

    void Start()
    {
        mainCamera = Camera.main;
        destination = transform.position;
    }

    void Update()
    {
        // Reads touch on mobile AND mouse click in the Simulator using the New Input System
        if (Pointer.current != null && Pointer.current.press.isPressed)
        {
            Vector2 touchPosition = Pointer.current.position.ReadValue();
            Vector3 worldTouch = mainCamera.ScreenToWorldPoint(touchPosition);
            destination = new Vector2(worldTouch.x, transform.position.y);
        }

        transform.position = Vector2.Lerp(transform.position, destination, speed * Time.deltaTime);

        float clampedX = Mathf.Clamp(transform.position.x, horizontalBoundary.min, horizontalBoundary.max);
        transform.position = new Vector3(clampedX, transform.position.y, 0.0f);
    }

    //private void GetTouchInput()
    //{
    //    // Checks if at least one finger is touching the screen
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
    //        Vector3 worldTouch = mainCamera.ScreenToWorldPoint(touch.position);
    //        destination = new Vector2(worldTouch.x, transform.position.y);
    //    }
    //    // Fallback for mouse dragging in the editor
    //    else if (Input.GetMouseButton(0))
    //    {
    //        Vector3 worldPoint = mainCamera.ScreenToWorldPoint(Input.mousePosition);
    //        destination = new Vector2(worldPoint.x, transform.position.y);
    //    }
    //}

    //private void Move()
    //{
    //    // Smoothly move toward the finger's X position
    //    transform.position = Vector2.Lerp(transform.position, destination, speed * Time.deltaTime);

    //    // Clamp X so the player never leaves the left or right edge of the screen
    //    float clampedX = Mathf.Clamp(transform.position.x, horizontalBoundary.min, horizontalBoundary.max);
    //    transform.position = new Vector3(clampedX, transform.position.y, 0.0f);
    //}
}
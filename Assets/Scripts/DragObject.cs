using UnityEngine;

/// <summary>
/// A class that allows an object to be clicked and dragged around
/// Sourced from: https://www.youtube.com/watch?v=0yHBDZHLRbQ&ab_channel=Jayanam
/// </summary>

public class DragObject : MonoBehaviour
{
    [SerializeField] private float offset = -1f;

    private Vector3 mOffset;
    private float mZCoord;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset) - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
        transform.rotation = Quaternion.identity;
        transform.localScale = originalScale;
    }
}
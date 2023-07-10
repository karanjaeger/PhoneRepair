using UnityEngine;

public class ComponentDragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 initialPosition;
    private Transform parentTransform;
    private SpriteRenderer spriteRenderer;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private Collider2D collider;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    public Transform trashBinTransform;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        parentTransform = transform.parent;
    }

    private void OnMouseDown()
    {
        isDragging = true;
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0f;
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;


        if (trashBinTransform != null && IsOverlapping(trashBinTransform))
        {

            HandleDamagedComponentDropped();
        }
        else
        {
            transform.position = initialPosition;
        }
    }

    private bool IsOverlapping(Transform targetTransform)
    {
        Collider2D targetCollider = targetTransform.GetComponent<Collider2D>();
        if (collider != null && targetCollider != null)
        {
            return collider.bounds.Intersects(targetCollider.bounds);
        }
        return false;
    }

    private void HandleDamagedComponentDropped()
    {
        Destroy(gameObject);
    }


}

using System.Collections.Generic;
using UnityEngine;

public class ComponentDragDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector2 initialPosition;
    private Transform parentTransform;
    private Vector2 clickOffset;
    private int sortingOrder;
    private SpriteRenderer spriteRenderer;
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
    private Collider2D collider;
#pragma warning restore CS0108 // Member hides inherited member; missing new keyword

    public Transform trashBinTransform;
    public Transform correctSlot;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        parentTransform = transform.parent;
        sortingOrder = this.spriteRenderer.sortingOrder;
    }
    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

    private void OnMouseDown()
    {
        isDragging = true;
        initialPosition = transform.position;
        clickOffset = (Vector2)transform.position - GetMouseWorldPosition();
        this.spriteRenderer.sortingOrder = 5;
    }

    private void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector2 newPosition = GetMouseWorldPosition() + clickOffset; 
            transform.position = newPosition;
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
        this.spriteRenderer.sortingOrder = sortingOrder;

        if(correctSlot == null)
        {
            if (trashBinTransform != null && IsOverlapping(trashBinTransform))
            {

                HandleDamagedComponentDropped();
            }
            else
            {
                transform.position = initialPosition;
                
            }
        }
        else
        {
            if (IsOverlapping(correctSlot))
            {
                transform.position = correctSlot.position;
                this.collider.enabled = false;
            }
            else
            {
                transform.position = initialPosition;
            }
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

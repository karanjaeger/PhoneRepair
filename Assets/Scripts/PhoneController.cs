using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhoneController : MonoBehaviour
{
    public PhoneScriptableObject phone;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = phone.phoneTopSprite;
        gameObject.AddComponent<BoxCollider2D>();
    }
    private void OnMouseUp()
    {
        Debug.Log("Clicked");
    }

}

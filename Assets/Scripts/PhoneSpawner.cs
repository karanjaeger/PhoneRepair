using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PhoneSpawner : MonoBehaviour
{
    public PhoneScriptableObject phone;
    public Transform parentTransform;

    void Start()
    {              
        InstantiatePhone();
    }
    private void OnMouseUp()
    {
        Debug.Log("Clicked");
    }

    void InstantiatePhone()
    {
        if (phone.phoneDamageType == "Screen")
        {
            PhoneBase("PhoneBase", phone.phoneBottomSprite, 0, false);
            PhoneBase("CrackedDisplay", phone.phoneTopSprite, 1, true);

        }
        else if (phone.phoneDamageType == "Component")
        {

        }
    }

    void PhoneBase(string name, Sprite phoneSprite, int sortingOrder, bool addCollider = false)
    {
        GameObject phoneObject = new GameObject(name);
        phoneObject.transform.parent = parentTransform;
        phoneObject.transform.localScale = Vector3.one;
        SpriteRenderer phoneBase = phoneObject.AddComponent<SpriteRenderer>();
        phoneBase.sprite = phoneSprite;
        phoneBase.sortingOrder = sortingOrder;
        if (addCollider)
        {
            BoxCollider2D collider = phoneObject.AddComponent<BoxCollider2D>();
        }
    }

}

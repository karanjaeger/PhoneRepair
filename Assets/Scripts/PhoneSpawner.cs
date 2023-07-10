using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PhoneSpawner : MonoBehaviour
{
    public PhoneScriptableObject phone;
    public Transform parentTransform;
    private Transform trashBin;

    void Start()
    {        
        InstantiatePhone();        

    }
    void Awake()
    {
        trashBin = GameObject.FindGameObjectWithTag("TrashBin").GetComponent<Transform>();
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
            PhoneBase("PhoneBase", phone.phoneBottomSprite, 0, false);

            PhoneBase("BackCover", phone.phoneTopSprite, 3, true);
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
            phoneObject.AddComponent<BoxCollider2D>();
            ComponentDragDrop dragDrop = phoneObject.AddComponent<ComponentDragDrop>();
            dragDrop.trashBinTransform = trashBin;
        }
    }

}

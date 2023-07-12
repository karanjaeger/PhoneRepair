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
    private SpriteRenderer backCover;
    private ComponentsManager ComponentsManager;

    void Start()
    {    
        InstantiatePhone();
        FadeOutOnClick.OnSpriteFade += EventHandler;
        
        if(backCover != null)
        {
            backCover.enabled = false;
        }
    }
    void EventHandler()
    {
        GameObject[] components = GameObject.FindGameObjectsWithTag("Event");
        foreach (GameObject component in components)
        {
            component.GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    void Awake()
    {        
        trashBin = GameObject.FindGameObjectWithTag("TrashBin").GetComponent<Transform>();
        ComponentsManager.OnPlaced += OnPlacedHandler;
    }

    private void OnDisable()
    {
        FadeOutOnClick.OnSpriteFade -= EventHandler;
        ComponentsManager.OnPlaced -= OnPlacedHandler;
    }

    void InstantiatePhone()
    {
        if (phone.phoneDamageType == "Screen")
        {
            PhoneBase("PhoneBase", phone.phoneBottomSprite, 0, false, false);
            PhoneBase("CrackedDisplay", phone.phoneTopSprite, 1, true, false);
            PhoneComponents();
            

        }
        else if (phone.phoneDamageType == "Component")
        {
            PhoneBase("PhoneBase", phone.phoneBottomSprite, 0, false);
            PhoneComponents();
            PhoneBase("BackCover", phone.phoneTopSprite, 3, true, true);
            backCover = GameObject.FindGameObjectWithTag("BackCover").GetComponent<SpriteRenderer>();
        }
    }

    void PhoneBase(string name, Sprite phoneSprite, int sortingOrder, bool addCollider = false, bool touchControl = false)
    {
        GameObject phoneObject = new GameObject(name);
        phoneObject.transform.parent = parentTransform;
        phoneObject.transform.localScale = Vector3.one;
        SpriteRenderer phoneBase = phoneObject.AddComponent<SpriteRenderer>();
        phoneBase.sprite = phoneSprite;
        phoneBase.sortingOrder = sortingOrder;
        if (!touchControl && addCollider)
        {
            phoneObject.AddComponent<BoxCollider2D>();
            ComponentDragDrop dragDrop = phoneObject.AddComponent<ComponentDragDrop>();
            dragDrop.trashBinTransform = trashBin;                      
        }
        else if (touchControl && addCollider)
        {
            phoneObject.AddComponent<BoxCollider2D>();
            phoneObject.AddComponent<FadeOutOnClick>();            
        }

    
    }

    void PhoneComponents()
    {
        GameObject gameComponents = Instantiate(phone.PhoneComponents);
        gameComponents.transform.parent = parentTransform;
        foreach (ComponentDragDrop script in gameComponents.GetComponentsInChildren<ComponentDragDrop>())
        {
            script.trashBinTransform = trashBin;
            script.tag = "Event";
        }     
        foreach (BoxCollider2D collider2D in gameComponents.GetComponentsInChildren(typeof(BoxCollider2D)))
        {
            collider2D.enabled = false;
        }
    }

    void OnPlacedHandler()
    {
        if(backCover != null)
        {
            StartCoroutine(BackCoverSpawn());
        }
        else
        {
            return;
        }
    }

    private IEnumerator BackCoverSpawn()
    {
        yield return new WaitForSeconds(1);
        backCover.enabled = true;
    }
}

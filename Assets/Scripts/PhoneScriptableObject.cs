using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PhoneScriptableObject", menuName ="ScriptableObject/PhoneScriptableObject")]
public class PhoneScriptableObject : ScriptableObject
{
    public string phoneName;
    public string phoneDamageType;
    public Sprite phoneTopSprite; 
    public Sprite phoneUnderSprite;


}
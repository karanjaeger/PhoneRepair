using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class Bridge : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void UnityEvent(string data);

    public void TriggerWebCall(string data)
    {
        UnityEvent(data);
    }
}

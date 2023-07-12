using UnityEngine;

public class ComponentsManager : MonoBehaviour
{
    private int damagedComponentCount = 0;
    private int newComponentCount = 0;
    public delegate void DamagedComponentDestroyed();
    public static event DamagedComponentDestroyed OnDestroyed;
    public delegate void NewComponentPlaced();
    public static event NewComponentPlaced OnPlaced;

    public void IncrementDamagedComponentCount()
    {
        damagedComponentCount++;
    }

    public void DecrementDamagedComponentCount()
    {
        damagedComponentCount--;
        if (damagedComponentCount <= 0)
        {
            
            Debug.Log("All damaged components are destroyed!");
            OnDestroyed();
        }
    }

    public void IncrementNewComponentCount()
    {
        newComponentCount++;
    }

    public void DecrementNewComponentCount()
    {
        newComponentCount--;
        if(newComponentCount <= 0)
        {
            Debug.Log("All components placed!");
            OnPlaced();
        }
    }
    
}

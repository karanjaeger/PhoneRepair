using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] gameObjects;

    private int currentIndex = 0;

    private void Start()
    {
       
        gameObjects[0].SetActive(true);
    }

    public void EnableNextGameObject()
    {
        
        gameObjects[currentIndex].SetActive(false);

       
        currentIndex++;

     
        if (currentIndex >= gameObjects.Length)
        {
        
            return;
        }

     
        gameObjects[currentIndex].SetActive(true);
    }
}

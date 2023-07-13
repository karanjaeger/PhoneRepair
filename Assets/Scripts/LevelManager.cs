using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject[] gameObjects;

    private int currentIndex = 0;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Image winImage;
    [SerializeField] private Bridge bridge;
    [SerializeField] private Timer timer;
    private AudioSource miniAudio;

    private void Start()
    {
        miniAudio = GetComponent<AudioSource>();
        winImage.enabled = false;
        gameObjects[0].SetActive(true);
    }

    public void EnableNextGameObject()
    {
        if(currentIndex != gameObjects.Length - 1)
        {
            miniAudio.Play();
        }
        gameObjects[currentIndex].SetActive(false);
        if (currentIndex == gameObjects.Length - 1)
        {
            StartCoroutine(WinCall());
        }


        currentIndex++;

     
        if (currentIndex >= gameObjects.Length)
        {
        
            return;
        }

     
        gameObjects[currentIndex].SetActive(true);
    }

    private IEnumerator WinCall()
    {
        timer.enabled = false;
        yield return new WaitForSeconds(1);
        audioSource.Play();
        winImage.enabled=true;
        yield return new WaitForSeconds(2);
        bridge.TriggerWebCall("winScenario");
    }
}

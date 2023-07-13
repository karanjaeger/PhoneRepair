using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float totalTime = 60f; 
    private Slider slider;  
    private float currentTime;
    private bool isDone;
    [SerializeField] private Bridge bridge;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Image loseImage;

    private void Start()
    {
        isDone = false;
        loseImage.enabled = false;
        slider = GetComponent<Slider>();  
        currentTime = totalTime;  
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;  
        slider.value = currentTime / totalTime;  

        if (currentTime <= 0f)
        {
            currentTime = 0f;
            if (!isDone)
            {
                StartCoroutine(loseCall());
                isDone = true;
            }              
        }
    }

    private IEnumerator loseCall()
    {
        yield return new WaitForSeconds(1);
        audioSource.Play();
        loseImage.enabled = true;
        yield return new WaitForSeconds(2);
        bridge.TriggerWebCall("loseScenario");
    }
}

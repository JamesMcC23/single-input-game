using UnityEngine;

public class door : MonoBehaviour, ITriggered
{
    private bool state;
    private ParticleSystem test;
    public interactible linked_switch;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        test = GetComponent<ParticleSystem>();
    }

    public void on_triggered()
    {
        state = !state;
    }

    public void Update()
    {
        Debug.Log($"door state = {state}");
        if(state == true)
        {
            test.Play();
        }
        else
        {
            test.Stop();
        }
    }
}

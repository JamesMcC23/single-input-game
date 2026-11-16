using UnityEngine;

public class trap : MonoBehaviour, ITriggered
{
    private ParticleSystem test;
    private bool state;
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
        Debug.Log($"trap state = {state}");
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


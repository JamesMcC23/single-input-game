using UnityEngine;

public class door : MonoBehaviour, ITriggered
{
    private bool state;
    private Animator animator_comp;
    public interactible linked_switch;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animator_comp = GetComponent<Animator>();
    }

    public void on_triggered(bool trigger_state)
    {
        state = trigger_state;
    }

    public void Update()
    {
        Debug.Log(state);
        if(state == true)
        {
            animator_comp.SetBool("is_open",true);
        }
        else
        {
            animator_comp.SetBool("is_open",false);
        }
    }
}

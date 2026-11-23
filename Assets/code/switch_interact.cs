using UnityEngine;

public class switch_interact : MonoBehaviour
{
    private interactible interact_script;
    private Animator animation_comp;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        animation_comp = GetComponent<Animator>();
        if(GetComponent<interactible>() != null)
        {
            interact_script = GetComponent<interactible>();
        }
        else
        {
            Debug.LogWarning("there is no interactible script present");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(interact_script.interact_switch == true)
        {
            animation_comp.SetBool("is_on",true);
        }
        else
        {
            animation_comp.SetBool("is_on",false);
        }
        
    }
}

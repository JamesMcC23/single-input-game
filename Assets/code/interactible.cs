using System;
using System.Collections.Generic;
using UnityEngine;

public class interactible : MonoBehaviour
{
    public bool interact_switch;
    public bool interact_button;
    private interaction_controls player_controller;
    private GameObject player;
    [SerializeField] private List<GameObject> trigger_objects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_controller = player.GetComponentInChildren<interaction_controls>();
        foreach (GameObject trigger_object  in trigger_objects)
        {
            if (trigger_object.TryGetComponent(out ITriggered itriggered))
            {
                //itriggered.linked_switch = this;
            }
        }
    }

    public void interaction()
    {
        Debug.Log("interaction running");
        
        interact_switch = !interact_switch; 
    
        foreach (GameObject trigger_object  in trigger_objects)
        {

            if (trigger_object.TryGetComponent(out ITriggered itriggered))
            {
                itriggered.on_triggered();
            }
            else
            {
                Debug.LogWarning($"{trigger_object} does not contain the correct method bozo");
            }
             
        }

    }

    public void Update()
    {
        interact_button = player_controller.button_control;
    }
}

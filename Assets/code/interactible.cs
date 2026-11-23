using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class interactible : MonoBehaviour
{
    public bool interact_switch;
    public bool switch_control;
    private interaction_controls player_controller;
    private GameObject player;

    private bool test;
    [SerializeField] private List<GameObject> trigger_objects;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_controller = player.GetComponentInChildren<interaction_controls>();
    }

    public void interaction(bool control)
    {
        Debug.Log("interaction running");
        
        if(switch_control == control)
        {
            interact_switch = !interact_switch;
            switch_control = !control;
        }
         
    
        foreach (GameObject trigger_object  in trigger_objects)
        {
            
            if (trigger_object.TryGetComponent(out ITriggered itriggered))
            {
                itriggered.on_triggered(interact_switch);
            }
            else
            {
                Debug.LogWarning($"{trigger_object} does not contain the correct method bozo");
            }
             
        }

    }


}

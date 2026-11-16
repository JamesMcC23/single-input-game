using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class interaction_controls : MonoBehaviour
{
    [SerializeField] private Camera player_camera;
    private Vector3 interaction_position;
    private Vector3 mouse_direction;
    public bool button_control = false;
    [SerializeField] private int player_reach = 10;

    void Start()
    {
    }

    void Update()
    {
        Vector2 mouse_pos = Mouse.current.position.ReadValue();
        mouse_direction = interaction_position - player_camera.transform.position;
        interaction_position = player_camera.ScreenToWorldPoint(new Vector3 (mouse_pos.x,mouse_pos.y, player_camera.nearClipPlane) + new Vector3(0,0,1));

        this.transform.position = interaction_position;
        RaycastHit hit;
        Physics.Raycast(player_camera.transform.position,mouse_direction.normalized, out hit, player_reach);

        if(hit.collider != null && hit.collider.CompareTag("interactible") && hit.collider.gameObject.GetComponent<interactible>())
        {
            trigger(hit);
            button_control = true;
        }
        else
        {
            button_control = false;
        }

        Debug.DrawRay(player_camera.transform.position,mouse_direction.normalized * player_reach,Color.green);
            
        
        
    }

    private void trigger(RaycastHit hit)
    {
        interactible interact_script;
        interact_script = hit.collider.gameObject.GetComponent<interactible>();
        interact_script.interaction();
        
    }

}

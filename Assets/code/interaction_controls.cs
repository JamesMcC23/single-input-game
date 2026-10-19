using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class interaction_controls : MonoBehaviour
{
    [SerializeField] private Camera player_camera;
    private Vector3 interaction_position;
    private Vector3 mouse_direction;
    [SerializeField] private int player_reach = 10;
    private ParticleSystem interact_particles;

    void Start()
    {
        interact_particles = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        Vector2 mouse_pos = Mouse.current.position.ReadValue();
        mouse_direction = interaction_position - player_camera.transform.position;
        interaction_position = player_camera.ScreenToWorldPoint(new Vector3 (mouse_pos.x,mouse_pos.y, player_camera.nearClipPlane) + new Vector3(0,0,1));

        this.transform.position = interaction_position;
        RaycastHit hit;
        Physics.Raycast(player_camera.transform.position,mouse_direction.normalized, out hit, player_reach);

        if(hit.collider != null)
        {
            if(hit.collider.CompareTag("interactible"))
            {
                Debug.Log(hit.collider.gameObject.name);
                interact_particles.transform.position = hit.collider.transform.position;
                interact_particles.Play();
            }
            else if(hit.collider.tag == null)
            {
                interact_particles.Stop();
            }
            else
            {
                interact_particles.Stop();
            }



        }

        Debug.DrawRay(player_camera.transform.position,mouse_direction.normalized * player_reach,Color.green);
        

    }

}

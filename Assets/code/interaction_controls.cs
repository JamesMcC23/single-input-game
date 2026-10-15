using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class interaction_controls : MonoBehaviour
{
    [SerializeField] private Camera player_camera;
    private Vector3 interaction_position;

    void Update()
    {
        Vector2 mouse_pos = Mouse.current.position.ReadValue();
        interaction_position = player_camera.ScreenToWorldPoint(new Vector3 (mouse_pos.x,mouse_pos.y, player_camera.nearClipPlane) + new Vector3(0,0,10));

        this.transform.position = interaction_position;
        RaycastHit hit;

        if(Physics.Raycast(player_camera.transform.position,(this.transform.position - interaction_position)* 100, out hit))
        {
            if(hit.collider.CompareTag("interactible"))
            {
                Debug.Log($"it hit <hit>");     
            }
            else 
            {
                Debug.Log("it didn't hit :(");
            }
        }
        Debug.DrawRay(player_camera.transform.position,(this.transform.position - interaction_position)* 100,Color.green);
        

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(player_camera.transform.position,(this.transform.position - interaction_position)*100);
    }

}

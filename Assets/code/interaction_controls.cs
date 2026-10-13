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
        interaction_position = player_camera.ScreenToWorldPoint(new Vector3 (mouse_pos.x,mouse_pos.y, player_camera.nearClipPlane));

        this.transform.position = interaction_position;

        Physics.Raycast(this.transform.position,this.transform.position - interaction_position, out RaycastHit hit , Mathf.Infinity);
        if(hit != null)
        {
            if(hit.collider.CompareTag("interactible"))
            {
            Debug.Log("it hit");
            }
            else
            {
                Debug.Log("it didn't hit :(");
            }
        }

    }

    private void OawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(this.transform.position,this.transform.position - interaction_position);
    }

}

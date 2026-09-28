using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class player_control : MonoBehaviour
{
    [SerializeField] private TMP_Text info_text;
    public Vector2 mouse_input;
    public Vector3 mousePos;
    [SerializeField] private bool view_x = false;

    
    void Awake()
    {
  
    }


    void Update()
    {
        Vector2 mouse_position = Mouse.current.position.ReadValue();
        info_text.transform.position = mouse_position;

        if(UnityEngine.InputSystem.Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            view_x = !view_x;
        }

        if(view_x == true)
        {
            info_text.text = string.Format("{0:N3}" , mouse_position.x);
        }
        else
        {
            info_text.text = string.Format("{0:N3}" , mouse_position.y);
        }

    }
}

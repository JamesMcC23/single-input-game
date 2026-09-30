using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.U2D;

public class player_control : MonoBehaviour
{
    [SerializeField] private Image cursor_image;
    
    private Vector2 mouse_position;
    private Vector2 current_mouse_position;
    [SerializeField] private float seconds_delay = 0.1f;
    bool enumerator_switch;
    [SerializeField] float rotate_speed;
    [SerializeField] float move_speed;
    [SerializeField] SpriteAtlas cursor_sprites;


    
    void Awake()
    {
        enumerator_switch = true;
    }


    void Update()
    {
        mouse_position = Mouse.current.position.ReadValue();
        cursor_image.transform.position = mouse_position;
        float rotate_parameter = (Screen.width / 2);
        float x_difference;
        float y_difference;
        

    

        

        // if (Mouse.current.leftButton.isPressed)
        // {
        //     transform.Translate(Vector3.forward * Time.deltaTime);
        // }

        if(mouse_position.y <= (Screen.height / 2))
        {
            
            
            if(mouse_position.x <= (Screen.width / 2))
            {
                //left hand side
                cursor_image.sprite = cursor_sprites.GetSprite("directional arrows_1");
                y_difference = current_mouse_position.y - mouse_position.y;
                if(y_difference > 0)
                {
                   //this.transform.position += new Vector3(0,0,move_speed * (y_difference/(Screen.height / 2)));
                   transform.Translate(new Vector3(0,0,move_speed * (y_difference/(Screen.height / 2))));
                }
       
            }
            else if(mouse_position.x >= (Screen.width / 2))
            {
                //right hand side
                cursor_image.sprite = cursor_sprites.GetSprite("directional arrows_0");
               x_difference = current_mouse_position.x - mouse_position.x;
                this.transform.localEulerAngles += new Vector3(0,rotate_speed * (x_difference/(Screen.width / 2)),0);

            }
            else
            {
                cursor_image.sprite = cursor_sprites.GetSprite("directional arrows_2");
            }
        }

        if(enumerator_switch == true)
        {
            enumerator_switch = false;
            StartCoroutine(mouse_position_per_frames());
        }

    }

    IEnumerator mouse_position_per_frames()
    {
        current_mouse_position = mouse_position;
        yield return new WaitForSeconds(seconds_delay);
        enumerator_switch = true;
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

public class interaction_controls : MonoBehaviour
{

    void Update()
    {
        this.transform.position = Mouse.current.position.ReadValue();
        
    }
}

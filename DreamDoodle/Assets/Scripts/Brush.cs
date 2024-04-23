using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Brush : MonoBehaviour
{
    public InputActionProperty buttonPressAction;
    public GameObject sphere;

    // Start is called before the first frame update
    void Start()
    {
        buttonPressAction.action.performed += Draw;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Draw(InputAction.CallbackContext ctx)
    {
        Instantiate(sphere, transform.position, Quaternion.identity);
    }
}

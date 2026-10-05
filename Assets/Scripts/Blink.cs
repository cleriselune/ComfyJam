using UnityEngine;
using UnityEngine.InputSystem;

public class Blink : MonoBehaviour
{
    public Canvas canvas;
    Keyboard keyboard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canvas.enabled = false; // disable the canvas at the start
    }

    void Update()
    {
        keyboard = Keyboard.current; // get the current keyboard input
        if (keyboard.eKey.wasPressedThisFrame){
            
            canvas.enabled = !canvas.enabled; // toggle the canvas visibility
            gameObject.tag = canvas.enabled ? "Blink" : "Player"; // change the tag based on the canvas visibility
            Debug.Log("tag: " + gameObject.tag);

        }
    }

}

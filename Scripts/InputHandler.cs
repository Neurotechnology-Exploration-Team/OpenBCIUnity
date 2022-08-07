using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [Header("Input Settings")] 
    
    // When this is true, use input from the OpenBCI scripts; when false, use conventional Unity inputs
    public bool useBCIInput = true;
    
    // TopDownCarController should be present on the same object as InputHandler
    TopDownCarController topDownCarController;
    
    // These are each other objects that exists in the scene
    // bciReaderIObject must have a script that implements OpenBCIReaderI
    public MonoBehaviour bciReaderIObject;
    // bciMenuIObject must have a script that implements BciMenuI
    public MonoBehaviour bciMenuIObject;
    
    // Awake will extract the scripts from the gameobjects into private references
    private OpenBCIReaderI bciReaderI;
    private BCIMenuI bciMenuI;

    // Awake is called when the script instance is being loaded.
    void Awake()
    {
        // controller is used to simulate car movement
        topDownCarController = GetComponent<TopDownCarController>();

        bciReaderI = bciReaderIObject.GetComponent<OpenBCIReaderI>();
        bciMenuI = bciMenuIObject.GetComponent<BCIMenuI>();

        // auto connect the open bci on startup
        bciReaderI.Reconnect();
        
        // either set these in the Unity editor or use code like this to define possible keybinds
        List<string> keybinds = new List<String>()
        {
            "Left",
            "Right",
            "Up",
            "Down"
        };
        bciMenuI.SetKeybindNames(keybinds);
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        if (useBCIInput)
        {
            inputVector.x = 0;
            inputVector.x -= bciMenuI.GetInputForKeybind("Left") ? 1 : 0;
            inputVector.x += bciMenuI.GetInputForKeybind("Right") ? 1 : 0;

            inputVector.y = 0;
            inputVector.x -= bciMenuI.GetInputForKeybind("Up") ? 1 : 0;
            inputVector.x += bciMenuI.GetInputForKeybind("Down") ? 1 : 0;
        }
        else
        {
            inputVector.x = Input.GetAxis("Horizontal");
            inputVector.y = Input.GetAxis("Vertical");
        }

        topDownCarController.SetVector(inputVector);
    }
}

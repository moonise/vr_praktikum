using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit; //import the XR Interaction Toolkit
using Bhaptics.SDK2; //import the Bhaptics SDK2

public class HapticGrab : MonoBehaviour
{
    public void OnGrab(SelectEnterEventArgs args)
    {
        // Find the controller that grabbed the object
        Transform hand = args.interactorObject.transform;

        Debug.Log("Grabbed by: " + hand.name);

        // Left hand haptic feedback
        if (hand.name.Contains("Left"))
        {
            BhapticsLibrary.Play("grab_left");
            Debug.Log("Left hand haptic played!");
        }
        // Right hand haptic feedback
        else if (hand.name.Contains("Right"))
        {
            BhapticsLibrary.Play("grab_right");
            Debug.Log("Right hand haptic played!");
        }
    }
}

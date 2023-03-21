using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstrProgression : MonoBehaviour
{
    public int step = 0;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshProUGUI instructions = GameObject.Find("Instructions").GetComponent<TextMeshProUGUI>();
        instructions.SetText("Drive up to the stop sign and come to a complete stop");
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI instructions = GameObject.Find("Instructions").GetComponent<TextMeshProUGUI>(); //Text
        Transform carPos = GameObject.Find("Car").GetComponent<Transform>(); //Car position
        Rigidbody rb = GameObject.Find("Car").GetComponent<Rigidbody>(); //Car ridgebody (for velocity)
        //Vector3 v3Velocity = rb.velocity;
        //instructions.SetText(carPos.position.ToString());

        // If still on "step 1", check if the car is infront of the stop sign and velocity=0
        if (step == 0 && (carPos.position[0] >= 0.95 && carPos.position[0] <= 1.05) && (carPos.position[1] >= -0.5 && carPos.position[1] <= -0.4) && (carPos.position[2] >= -7.8 && carPos.position[2] <= -6.438519) && rb.velocity[0] == 0)
        {
            instructions.SetText("Good job! Remember to be aware before you enter an intersection, now have fun exploring!");
            step = step + 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanMove : NPCMove
{
    // Start is called before the first frame update
    protected override void Start() // Override the protected virtual method
    {
        navMeshArea = "Human"; // Set this to Human for the human object
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

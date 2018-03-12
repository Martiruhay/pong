using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static bool right, left, action;
	
	void Update ()
    {
        right = Input.GetKey(KeyCode.RightArrow);
        left = Input.GetKey(KeyCode.LeftArrow);
        action = Input.GetKeyDown(KeyCode.Space);
	}
}

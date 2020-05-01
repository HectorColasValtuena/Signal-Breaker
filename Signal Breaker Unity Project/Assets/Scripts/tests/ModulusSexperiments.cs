using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModulusSexperiments : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{
		LogModulus(0, 6);
		LogModulus(3, 6);
		LogModulus(6, 6);
		LogModulus(9, 6);
		LogModulus(12, 6);
		LogModulus(-3, 6);
		LogModulus(-6, 6);
		LogModulus(-8, 6);
		LogModulus(-10, 6);
		LogModulus(-12, 6);
		LogModulus(3, -6);
		LogModulus(6, -6);
		LogModulus(8, -6);
		LogModulus(10, -6);
		LogModulus(12, -6);
		LogModulus(-3, -6);
		LogModulus(-6, -6);
		LogModulus(-8, -6);
		LogModulus(-10, -6);
		LogModulus(-12, -6);
	}

	void LogModulus (int first, int second)
	{
		Debug.Log(first + " % " + second + " = " + (first%second));
	}
}

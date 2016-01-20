using UnityEngine;
using System.Collections;

public class CubeCandela : MonoBehaviour {
	Light flashlight;
	public float number=1.0f;
	public float EnergyLuce = 0.0f;
	// Use this for initialization
	void Start()
	{
		flashlight = GetComponentInChildren<Light>();
	}

	// Update is called once per frame
	void Update()
	{
		EnergyLuce += number + Time.deltaTime;

		if (EnergyLuce >= 1000.0f) {

			flashlight.enabled = false;
		}
	}
}

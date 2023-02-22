using System;
using UnityEngine;
//Namespace de codigo relacionado al audio, a este si quieres no le muevas
namespace AudioManager {
	
	//Una clase para implementar variables especiales con un rango
	[Serializable]
	public struct RangedFloat {
		[Range(0f, 2f)]public float minValue;
		[Range(0f, 2f)]public float maxValue;
	}
}
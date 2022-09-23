using System;
using UnityEngine;

namespace AudioManager {
	
	[Serializable]
	public struct RangedFloat {
		[Range(0f, 2f)]public float minValue;
		[Range(0f, 2f)]public float maxValue;
	}
}
using System.Collections.Generic;
using UnityEngine;

namespace Equipments {
	
	[CreateAssetMenu(fileName = "New Inventory", menuName = "Equipments/Inventory")]
	public class Inventory : ScriptableObject {
		public List<Equipment> wingsInventory;
		public List<Equipment> cabineInventory;
		public List<Equipment> engineInventory;
		public List<Equipment> bodyInventory;

		public void PickUpWings(Equipment wing) {
			wingsInventory.Add(wing);
		}
		
		public void PickUpCabine(Equipment cabine) {
			cabineInventory.Add(cabine);
		}
		
		public void PickUpEngine(Equipment engine) {
			engineInventory.Add(engine);
		}
		
		public void PickUpBody(Equipment body) {
			bodyInventory.Add(body);
		}
	}
}
using System;
using UnityEngine;

namespace Equipments {
	public class DropManager : MonoBehaviour {
		public Equipment equipment;

		public void Drop() {
			equipment.OnDrop(transform.position);
		}

		private void OnTriggerEnter2D(Collider2D col) {
			if (!col.CompareTag("player"))
				return;
			var equipmentManager = col.GetComponent<EquipmentManager>();
			switch (equipment.equipmentType) {
				case EquipmentType.Body:
					equipmentManager.inventory.PickUpBody(equipment);
					break;
				case EquipmentType.Wings:
					equipmentManager.inventory.PickUpWings(equipment);
					break;
				case EquipmentType.Cabine:
					equipmentManager.inventory.PickUpCabine(equipment);
					break;
				case EquipmentType.Engine:
					equipmentManager.inventory.PickUpEngine(equipment);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}
}
using System;
using UnityEngine;
//namespace de los equipments, aqui va el codigo relacionado con los items
namespace Equipments {
	//Esta clase se encarga del sistema para los drops, no esta terminado, aqui deberias empezar junto con el inventario
	public class DropManager : MonoBehaviour {
		//Este serian los datos del equipo a dropearse
		public Equipment equipment;
		
		//el metodo que se llama para soltar el item, no esta terminao
		public void Drop() {
			equipment.OnDrop(transform.position);
		}
		
		//Este controlaria el collider y haría que el jugador pudiera recolectar el objeto
		//No es un sistema completo lo puedes rehacer como tu quieras
		private void OnTriggerEnter2D(Collider2D col) {
			//Se comprueba que sea un jugador recolectando
			if (!col.CompareTag("player"))
				return;
			//Se hace la referencia al equipmentmanager que maneja el inventario
			var equipmentManager = col.GetComponent<EquipmentManager>();
			//Coloca el objeto en el slot de inventario que le corresponde segun el tipo de item
			//De nuevo, lo puedes rehacer
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
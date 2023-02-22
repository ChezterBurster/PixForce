using System.Collections.Generic;
using UnityEngine;
//namespace de los equipments, aqui va el codigo relacionado con los items
namespace Equipments {
	
	//Archivo de datos que contiene el inventario del jugador, se crea desde el inspector
	//Esta clase lo puedes rehacer si te parece mejor otro sisteme de inventario
	[CreateAssetMenu(fileName = "New Inventory", menuName = "Equipments/Inventory")]
	public class Inventory : ScriptableObject {
		//Listas para los diferentes items, creo que faltaria una para armas, idk
		public List<Equipment> wingsInventory;
		public List<Equipment> cabineInventory;
		public List<Equipment> engineInventory;
		public List<Equipment> bodyInventory;

		//metodo para asignar las alas a su slot correspondiente
		public void PickUpWings(Equipment wing) {
			wingsInventory.Add(wing);
		}
		//metodo para asignar las cabinas a su slot correspondiente
		public void PickUpCabine(Equipment cabine) {
			cabineInventory.Add(cabine);
		}
		//metodo para asignar los motores a su slot correspondiente
		public void PickUpEngine(Equipment engine) {
			engineInventory.Add(engine);
		}
		//metodo para asignar los cuerpos de nave a su slot correspondiente
		public void PickUpBody(Equipment body) {
			bodyInventory.Add(body);
		}
	}
}
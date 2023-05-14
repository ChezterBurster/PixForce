using UnityEngine;

//este controla los enemgos, planeaba cambiarlo para tener diferentes comportamientos
//Mejor hay que hacer otros dos para que sea uno para cada tipo de nave
public class EnemyControllerEdit : MonoBehaviour {

    //Lo basico que debe tener cada entidad
    private Transform _enemyTransform;
    [HideInInspector] public Transform player;
   
    
    
    private void Awake() {
        //Se inicializa la entidad
        _enemyTransform = transform;
        
    }

  

    private void Update() {
        //Nos aseguramos de que exista una enitdad jugador en la escena
        if (player == null)
            return;
        
        //A partir de aqui está el comportamiento de la entidad
        //Para el enemigo generico consiste en hacer objetivo al jugador y moverse en diagonal por la escena
        LookAtPlayer();
        
    }

    //Metodo para calcular la velocidad y tenga el comportamiento esperado que menciono en el update

    //Logica para hacer objetivo al jugador
    private void LookAtPlayer() {
        var direction = player.position - _enemyTransform.position;
        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        var rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        _enemyTransform.rotation = rotation;
    }


}

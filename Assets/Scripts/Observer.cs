using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class Observer : MonoBehaviour
{
    public Transform player;

    private bool isPlayerInRange;
    public GameEnding gameEnding;

    private void OnTriggerEnter(Collider other){
        //activamos el triger para realizar un tipo de accion 
        if (other.transform == player){
            isPlayerInRange = true;
        }

    }

    private void OnTriggerExit(Collider other){
        if (other.transform == player){
            isPlayerInRange = false;
        }

    }

    private void Update()
    {
        if (isPlayerInRange){
            //campo de vision de nuestra gargola; genera la vision al centro del personaje
            Vector3 direction = player.position - transform.position +Vector3.up;
            
            //con esta linea de codigo dibujamos el rayo para ver si funciona o no 
            Debug.DrawRay(transform.position, direction, Color.magenta, Time.deltaTime, true);


            //se asigna un parametro para almacenar la info
            RaycastHit raycastHit;
            //detectara a nuestro personaje segun el origen y el rango de vision 
            Ray ray = new Ray(transform.position, direction);
            //nuestro rayo chocara con algo en este caso el personaje
            //el motor de fisicas verificara contra que esta chocando
            if (Physics.Raycast(ray, out raycastHit)){
                //si chocamos con un collider eso nos dice que fue contra el personaje
                if (raycastHit.collider.transform==player){
                    //aqui es donde cambia el valor de la variable cuando el rayo ve al jugador
                    gameEnding.CatchPalyer();
                }
            }
        }
        //throw new NotImplementedException();
        
    }

//se actualiza el metodo para los gizmos y en este caso se identifiquen los objetos 
// este metodo para ubicar objetos principalmente
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, player.position+Vector3.up);
    }

}

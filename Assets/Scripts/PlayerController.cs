using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 movement;
    private Quaternion rotation = Quaternion.identity;
    private Animator _animator;
    private Rigidbody _rigidbody;
    private AudioSource _audioSource;

    [SerializeField]
    private float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    // fixed update frame de fisicas
    void FixedUpdate()
    {
        //para dar el movimiento al personaje 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        //configurar las coordenadas en x,y,z
        movement.Set(horizontal, 0, vertical);
        //normizar para que todo tenga la misma longitud
        movement.Normalize();

        //se convierte en booleano para que haga el movimiento
        bool hasHorizontalInput = ! Mathf.Approximately(horizontal, 0f);
        bool hasVErticalInput = ! Mathf.Approximately(vertical, 0f);
        //para dar movimiento a la animacion
        bool isWalking = hasHorizontalInput || hasVErticalInput;

        //para que se verifique que la animacion esta o no en true
        //y que comience a caminar con W,a,s,d
        _animator.SetBool("isWolking", isWalking);

        if (isWalking){
            //si el audio no suena entonces
            if (!_audioSource.isPlaying){
                _audioSource.Play();
            }
        } else {
            _audioSource.Stop();
        }

        //direccion que me gustaria estar mirando
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward,
            movement, turnSpeed* Time.fixedDeltaTime, 0f);

        //para rotar la animación se usa Quaternion
        rotation = Quaternion.LookRotation(desiredForward);

    }

    private void OnAnimatorMove() {
       _rigidbody.MovePosition(_rigidbody.position + movement * _animator.deltaPosition.magnitude);
       _rigidbody.MoveRotation(rotation);
    }


}

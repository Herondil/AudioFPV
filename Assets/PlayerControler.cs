using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour 
{ 
    //fields en public pour les avoir 

    //trois fields de type Vector2
    public Vector2  _mouseSensitivity,
                    _padSensitivity,
                    _mouseYLimit;

    //peut-être un déplacement ?
    public float _horizontal,
                 _vertical;

    //vitesse de déplacement
    public float _speed;

    //Méthode 60 fois par seconde ?
    void Update()
    {
        UpdateCamera();
        UpdateMovement();
    }
   

    void UpdateMovement()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        Vector3 direction = transform.right * horizontalInput + transform.forward * verticalInput;

        direction *= _speed * Time.deltaTime;

        //récupérer l'objet Character Controller attaché au Game Object
        CharacterController characterController = GetComponent<CharacterController>();

        characterController.Move(direction);
    }

    void UpdateCamera()
    {
        //deux variables locales à Update
        float    mouseX = Input.GetAxis("Mouse X"),
                 mouseY = Input.GetAxis("Mouse Y");

        float   GamePadX = Input.GetAxis("RHorizontal"),
                GamePadY = Input.GetAxis("RVertical");

        Transform _cameraTransform = Camera.main.transform;

        _horizontal = _horizontal + mouseX * _mouseSensitivity.x + GamePadX;
        _vertical   = _vertical + mouseY * _mouseSensitivity.y + GamePadY;

        _vertical = Mathf.Clamp(_vertical, _mouseYLimit.x, _mouseYLimit.y);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _horizontal, transform.eulerAngles.z);
        _cameraTransform.eulerAngles = new Vector3(_vertical, _cameraTransform.eulerAngles.y, _cameraTransform.eulerAngles.z);
    }
}

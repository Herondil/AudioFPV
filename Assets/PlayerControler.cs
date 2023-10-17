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

    //Méthode 60 fois par seconde ?
    void Update()
    {
        //deux variables locales à Update
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Transform _cameraTransform = Camera.main.transform;

        _horizontal += mouseX* _mouseSensitivity.x;
        _vertical   += mouseY* _mouseSensitivity.y;

        _vertical = Mathf.Clamp(_vertical, _mouseYLimit.x, _mouseYLimit.y);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, _horizontal, transform.eulerAngles.z);
        _cameraTransform.eulerAngles = new Vector3(_vertical, _cameraTransform.eulerAngles.y, _cameraTransform.eulerAngles.z);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulance : MonoBehaviour
{
    #region Show in Inspector

    [Header("Monitoring")]
    [SerializeField]
    private bool _facingNorth;
    [Space]
    [Header("Movement Settings")]
    [Min(0)]
    [SerializeField]
    private float _speed = 20f;
    [SerializeField]
    private float _maxDistance = 0f;
    [SerializeField]
    private float _minDistance = -200f;

    #endregion

    #region Init

    private void Awake()
    {
        // On recupère les composants internes, on détermine une direction et une vélocité de départ
        _rigidbody = GetComponent<Rigidbody>();
        _transform = transform;
        _facingNorth = true;
        PushForward();
    }

    #endregion

    #region Update

    private void Update()
    {
        // Si l'on va en avant et que l'on a atteint ou dépassé la distance max
        if (_facingNorth && _transform.position.z >= _maxDistance)
        {
            // On snap la position sur la distance max pour éviter les décalages
            _transform.position = new Vector3(_transform.position.x, _transform.position.y, _maxDistance);
            // Puis on fait demi-tour
            UTurn();
        }
        // Si l'on va en arrière et que l'on a atteint ou dépassé la distance min
        else if (!_facingNorth && _transform.position.z <= _minDistance)
        {
            // On snap la position sur la distance min pour éviter les décalages
            _transform.position = new Vector3(_transform.position.x, _transform.position.y, _minDistance);
            // Puis on fait demi-tour
            UTurn();
        }
    }

    #endregion

    #region Private methods

    private void PushForward()
    {
        // On donne une velocité basée sur le forward du transform
        _rigidbody.velocity = _transform.forward * _speed;
    }

    private void UTurn()
    {
        // On inverse le forward du transform en Z pour le retourner
        _transform.forward = -_transform.forward;
        // On inverse la valeur de la variable indiquant notre direction actuelle (aller 0 ou retour 1)
        _facingNorth = !_facingNorth;
        // On fait demi-tour
        PushForward();
    }

    #endregion

    #region Private members

    private Transform _transform;
    private Rigidbody _rigidbody;

    #endregion
}

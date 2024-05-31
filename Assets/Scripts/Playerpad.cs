using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerpad : Player
{
    public float maxYPosition = 4.0f; // Limite sup�rieure de d�placement du palet
    public float minYPosition = -4.0f; // Limite inf�rieure de d�placement du palet

    private Vector2 _direction;

    private void Update()
    {
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow)){
            _direction = Vector2.up;
        } else if (Input.GetKey(KeyCode.Z) || Input.GetKey(KeyCode.DownArrow)) {
            _direction = Vector2.down;
        } else { 
            _direction = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (_direction.sqrMagnitude != 0)
        {
            // Ajouter la direction au palet
            Vector2 newPosition = (Vector2)transform.position + _direction * this.speed * Time.fixedDeltaTime;

            // Limiter la nouvelle position � la moiti� sup�rieure de l'�cran
            newPosition.y = Mathf.Clamp(newPosition.y, minYPosition, maxYPosition);

            // D�finir la nouvelle position
            _rigidbody.MovePosition(newPosition);
        }
    }

}

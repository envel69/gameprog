using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ordinator : Player
{
    public Rigidbody2D ball;

    private void FixedUpdate()
    {
        if (this.ball.velocity.x > 0.0f)
        {
            if (this.ball.velocity.y > this.transform.position.y)
            {
                _rigidbody.AddForce(Vector2.up * this.speed);
            } else if (this.ball.position.y < this.transform.position.y){
                _rigidbody.AddForce(Vector2.down * this.speed);
            }
        }
    }
}

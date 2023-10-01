using UnityEngine;

namespace PlayerSystem
{
    public class PlayerMovement 
    {
        public void Move(Rigidbody2D rigidbody2D,float speed, Vector2 moveDir)
        {
            Vector2 velocity = moveDir * speed;
            rigidbody2D.velocity = new Vector2(velocity.x,velocity.y);
        }
    }
}

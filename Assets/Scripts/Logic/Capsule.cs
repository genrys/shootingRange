namespace ShootingGallery.Logic
{
    using Core;
    using UnityEngine;
    
    public class Capsule : ShootObject
    {
        private float _jumpBoundary;

        private bool _isChangeDirection;

        public override void Init()
        {
            ObjectColor = Color.red;
            SetColor();
            DirectionVector = Vector3.up;
            _jumpBoundary = 2f;
            ObjectSpeed = 0.8f;
        }

        public override void MoveRotation()
        {
            if (transform.position.y > _jumpBoundary && !_isChangeDirection)
            {
                UpdateParameters(-Vector3.up, 0.4f);

            }
            else if (transform.position.y < 1.3 && _isChangeDirection)
            {
                UpdateParameters(Vector3.up, 0.8f);
            }

            transform.Translate(DirectionVector * Time.deltaTime * ObjectSpeed);
        }

        public override void UpdateParameters(Vector3 newDirection, float newSpeed)
        {
            DirectionVector = newDirection;
            ObjectSpeed = newSpeed;
            _isChangeDirection = !_isChangeDirection;
        }
    }
}

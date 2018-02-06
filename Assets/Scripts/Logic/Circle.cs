namespace ShootingGallery.Logic
{
    using Core;
    using UnityEngine;

    public class Circle : ShootObject
    {
        private bool _isChangeDirection;

        public override void Init()
        {
            ObjectColor = Color.yellow;
            SetColor();
            DirectionVector = new Vector3(-1, 0, 0);
            ObjectSpeed = 0.4f;
        }

        public override void MoveRotation()
        {
            if (transform.position.x < CurrentSpawn.TransformObject.position.x -0.25 && !_isChangeDirection)
            {
                UpdateParameters(Vector3.right,0.4f);
            }
            else if (transform.position.x > CurrentSpawn.TransformObject.position.x + 0.25 && _isChangeDirection)
            {
                UpdateParameters(Vector3.left, 0.4f);
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

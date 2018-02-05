namespace ShootingGallery.Logic
{
    using System;
    using Core;
    using UnityEngine;

    public class Cube : ShootObject
    {
        public override void Init()
        {
            ObjectColor = Color.black;
            SetColor();
            DirectionVector = new Vector3(-1, -1, -1);
        }

        public override void MoveRotation()
        {
            transform.Rotate(DirectionVector);
        }

        public override void UpdateParameters(Vector3 dir, float speed)
        {
            throw new NotImplementedException();
        }
    }
}
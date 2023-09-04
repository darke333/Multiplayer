using System;
using UnityEngine;

namespace Input
{
    public class IInputActions
    {
        public event Action Jump;
        public event Action Dodge;
        public event Action<Vector2> Movement;
    }
}
using System;
using Landscape;
using Movement;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.Assertions;
using Utils;

namespace Creatures
{
    public abstract class Animal : Creature
    {
        /// <summary>
        /// Responsible for physical aspects of an animal: movement, HP, hunger etc.
        /// </summary>
        [NonSerialized]
        public Moveset moveset;
        public Vector2Int faceDirection = Vector2Int.up;

        public abstract void Move(Vector2Int destination, float duration);
    }
}

﻿using UnityEngine;

namespace ShmupBoss
{
    /// <summary>
    /// Items with a percentile chance of spawning which are generated by enemies when eliminated.
    /// </summary>
    [System.Serializable]
    public class Drop
    {
        public Pickup PickupPrefab;

        [Tooltip("The percentile chance of a drop, a value of 100 means making the drop when the enemy " +
            "is eliminated is certain while a value of 50 means there is a 50% chance.")]
        [Range(0, 100)]
        public float DropChance = 100;
    }
}
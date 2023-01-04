using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;



namespace ActionControl
{
    public class TimeController: MonoBehaviour
    {
        public float nextMove;
        public TurnQueue turnQueue;

        public TimeController(TurnQueue turnQueue)
        {
            this.turnQueue = turnQueue;
        }

        public void Update()
        {
            if (Time.time > nextMove)
            {
                turnQueue.RunNextTurn();
                nextMove = Time.time + 1;
            }
        }
    }
}
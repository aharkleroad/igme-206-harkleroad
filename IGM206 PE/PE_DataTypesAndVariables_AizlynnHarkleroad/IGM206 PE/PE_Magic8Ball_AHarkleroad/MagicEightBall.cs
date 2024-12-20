﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Magic8Ball_AHarkleroad
{
    internal class MagicEightBall
    {
        private string owner;
        private int timesShaken;
        private string[] responses;
        private Random getResponse;

        // MagicEightBall object constructor
        public MagicEightBall(string owner)
        {
            this.owner = owner;
            timesShaken = 0;
            responses = new string[] {"yes", "no", "maybe", "never", "without a doubt", "ask again later"};
            getResponse = new Random();
        }

        public string ShakeBall()
        {
            int responseIndex = getResponse.Next(0,6);
            timesShaken++;
            return responses[responseIndex];
        }

        public string Report()
        {
            if (timesShaken == 0) 
            {
                return (owner + " has not shaken the ball yet");
            }
            else if (timesShaken > 0 && timesShaken <= 3)
            {
                return (owner + " has shaken the ball " + timesShaken + " times");
            }
            else
            {
                return (owner + " has shaken the ball " + timesShaken + " times. That's a lot of questions!");
            }
        }
    }
}

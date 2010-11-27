﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringEvolver.FitnessCalculators;

namespace StringEvolver.Operators.Selection
{
    class RouletteWheelSelection:ISelection
    {
        private readonly Random random;
        private readonly IFitnessCalculator fitnessCalculator;

        public RouletteWheelSelection(IFitnessCalculator fitnessCalculator)
        {
            this.fitnessCalculator = fitnessCalculator;
            random = new Random();
        }

        public Chromosome Select(Population population)
        {
            var ran = random.NextDouble(0, population.Fitness);
            double sum = 0;
            foreach (var chromosome in population)
            {
                sum += chromosome.Fitness;
                if (sum > ran)
                {
                    return chromosome;
                }
            }
            throw new Exception("A chromosome should always be selected");
        }
    }
}
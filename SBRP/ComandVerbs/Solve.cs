﻿using CommandLine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP.ComandVerbs
{
    [Verb("solve", HelpText = "Solve the problem using genetic algorithm")]
    class Solve
    {

        [Option('s', "bus-stops-file", HelpText = "The file contain the bus stops data", Required = true)]
        public string BusStops { get; set; }

        [Option('d', "dmat-file", HelpText = "The file contain the distance matrix data", Required = true)]
        public string DistanceMatrix { get; set; }

        [Option('b', "num-buses", HelpText = "The number of buses", Required = true)]
        public int NumBuses { get; set; }

        [Option("crossover", HelpText = "The crossover rate (0 .. 1)", Required = false, Default = 0.95)]
        public double CrossoverRate { get; set; }

        [Option("mutation", HelpText = "The mutation rate (0..1)", Required = false, Default = 0.1)]
        public double MutationRate { get; set; }

        [Option('e', "elitism", HelpText = "The elitism number ( < the size of the problem)", Required = false, Default = 5)]
        public int ElitismNumber { get; set; }

        [Option('c', "bus-capacity", HelpText = "The capacity of each bus", Default = 30)]
        public int BusCapacity { get; set; }

        [Option("mrt", HelpText = "The maximum riding time in minutes", Default = 30)]
        public double MaxRidingTime { get; set; }

        [Option('p', "population-size", HelpText = "The population size for genetic algorithm", Default = 200)]
        public int PopulationSize { get; set; }

        [Option('g', "num-generations", HelpText = "The maximum number of generations", Default = 200)]
        public int NumGenerations { get; set; }
    }
}

using SBRP.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Kang, M., Kim, S., Felan, J. T., Choi, H. R., & Cho, M. (2015). Development of a Genetic Algorithm for the School Bus Routing Problem. International Journal of Software Engineering and Its Applications, 9(5), 107–126. http://doi.org/10.14257/ijseia.2015.9.5.11
/// </summary>
namespace SBRP.Algorithms.GeneticKang2015
{
    class GeneticKang2015
    {
        public double CrossoverRate { get; set; }
        public double MutationRate { get; set; }
        public int ElitismNumber { get; set; }
        public int PopulationSize { get; set; }
        public int NumberOfGenerations { get; set; }
        public double SelectionRatio { get; set; }

        private SchoolBusRoutingProblem _sbrp;
        private OutputInterface _output;
        private Random _rand;

        private Population _population;

        public GeneticKang2015(SchoolBusRoutingProblem sbrp, OutputInterface output)
        {
            this._sbrp = sbrp;
            this._output = output;
            this._rand = new Random();
        }

        public void run()
        {
            double r;
            this._generateInitialPopulation();
            this._sort();

            int generation = 0;
            this._population.getEntityAt(0).printBeautifully();
            this._output.printLine(String.Format("Generation: {0} - Best solution fitness {1} ({2})", generation, this._population.getBestFitness(), this._population.getBestSolutionRoutesLength(this._sbrp.DistanceMatrix)));
            

            for (generation = 1; generation <= this.NumberOfGenerations; generation++)
            {
                // generate offspring
                Population newPopulation = new Population();
                while (newPopulation.CurrentPopulation < this.PopulationSize)
                {
                    Entity child = null;
                    r = this._rand.NextDouble();
                    if (r < this.CrossoverRate)
                    {
                        // Select 2 parents by seed selection
                        Entity male = null;
                        Entity female = null;

                        this._selectTwoParents(ref male, ref female);

                        // Apply crossover and select the better child
                        child = this._crossover(male, female);

                        // Apply 6-case mutation to the selected child
                        child = this._mutation6Case(child);
                    }
                    else
                    {
                        r = this._rand.NextDouble();
                        // Select an individual randomly from the current population
                        Entity ent = null;
                        this._selectOneParent(ref ent);

                        if (r < this.MutationRate)
                        {
                            // Apply 5-case mutation to the selected individual
                            child = this._mutation5Case(ent);
                        }
                        else
                        {
                            // Copy the selected individual
                            child = new Entity(this._sbrp.NumBuses, ent.getChromosome());
                        }
                    }

                    // repair the new individual
                    this._repair(child);

                    // add the new individual to the new population
                    newPopulation.addEntity(child);
                }
                this._updateElites(newPopulation);
                this._population = newPopulation;
                this._sort();
                this._population.getEntityAt(0).printBeautifully();
                this._output.printLine(String.Format("Generation: {0} - Best solution fitness {1} \n({2})\n", generation, this._population.getBestFitness(), this._population.getBestSolutionRoutesLength(this._sbrp.DistanceMatrix)));
            }

            Console.WriteLine("Solution found");
            this._population.getEntityAt(0).printBeautifully();

            r = this._rand.NextDouble();
        }

        private void _generateInitialPopulation()
        {
            this._population = new Population();
            int[] busStopStudents = this._sbrp.BusStops.Select(st => st.NumStudent).ToArray();
            while (this._population.CurrentPopulation < this.PopulationSize)
            {
                // Allocate buses to bus stops
                List<int> buses = Enumerable.Range(1, this._sbrp.NumBuses).ToList();
                List<int> busStops = Enumerable.Range(1, this._sbrp.NumBusStops).ToList();
                Entity entity = new Entity(this._sbrp.NumBuses, this._sbrp.BusStops.Length);
                int index, bus, busStop;

                index = this._rand.Next(0, buses.Count - 1);
                bus = buses[index];
                buses.RemoveAt(index);

                while (busStops.Count > 0)
                {
                    index = this._rand.Next(0, busStops.Count - 1);
                    busStop = busStops[index];
                    busStops.RemoveAt(index);

                    // if the distance constraint is violated, we choose a new bus
                    if (!entity.assignBusToBusStop(bus, busStop, busStopStudents, this._sbrp.DistanceMatrix, this._sbrp.VehicleCapacity, this._sbrp.MaxRiddingTime))
                    {
                        index = this._rand.Next(0, buses.Count - 1);
                        bus = buses[index];
                        buses.RemoveAt(index);
                        entity.assignBusToBusStop(bus, busStop, busStopStudents, this._sbrp.DistanceMatrix, this._sbrp.VehicleCapacity, this._sbrp.MaxRiddingTime);
                    }
                }

                this._population.addEntity(entity.encode());

            }
        }

        /// <summary>
        /// Sort the population by the fitness
        /// </summary>
        private void _sort()
        {
            this._population.sortEntities(this._calculateFitness);
        }

        /// <summary>
        /// Replace worst entities from the new population with the elites of the current population
        /// </summary>
        /// <param name="newPopulation"></param>
        private void _updateElites(Population newPopulation)
        {
            newPopulation.sortEntities(this._calculateFitness);
            int popSize = newPopulation.CurrentPopulation;
            for (var i = 0; i < this.ElitismNumber; i++)
            {
                newPopulation.setEntityAt(popSize - 1 - i, this._population.getEntityAt(i));
            }
        }
        private Entity _crossover(Entity maleParent, Entity femaleParent)
        {
            int point1, point2;

            point1 = this._rand.Next(0, this._sbrp.NumBusStops - 2);
            do
            {
                point2 = this._rand.Next(0, this._sbrp.NumBusStops - 2);
            } while (point2 == point1);

            if (point1 > point2)
            {
                // swap point1 and point2
                point1 = point1 + point2;
                point2 = point1 - point2;
                point1 = point1 - point2;
            }

            int[][] maleChromosome = maleParent.getChromosome();
            int[][] femaleChromosome = femaleParent.getChromosome();

            int[][] child1Chromosome = new int[this._sbrp.NumBusStops][];
            int[][] child2Chromosome = new int[this._sbrp.NumBusStops][];

            for (var i = 0; i <= point1; i++)
            {
                child1Chromosome[i] = new int[2] { maleChromosome[i][0], maleChromosome[i][1] };
                child2Chromosome[i] = new int[2] { femaleChromosome[i][0], femaleChromosome[i][1] };
            }

            for (var i = point1 + 1; i <= point2; i++)
            {
                child1Chromosome[i] = new int[2] { femaleChromosome[i][0], femaleChromosome[i][1] };
                child2Chromosome[i] = new int[2] { maleChromosome[i][0], maleChromosome[i][1] };
            }

            for (var i = point2 + 1; i <= this._sbrp.NumBusStops - 1; i++)
            {
                child1Chromosome[i] = new int[2] { maleChromosome[i][0], maleChromosome[i][1] };
                child2Chromosome[i] = new int[2] { femaleChromosome[i][0], femaleChromosome[i][1] };
            }

            Entity child1 = new Entity(this._sbrp.NumBuses, child1Chromosome);
            Entity child2 = new Entity(this._sbrp.NumBuses, child2Chromosome);

            double fitness1 = this._calculateFitness(child1);
            double fitness2 = this._calculateFitness(child2);

            return fitness1 > fitness2 ? child2 : child1;
        }
        private Entity _mutation5Case(Entity entity)
        {
            int[][] chromosome0 = entity.getChromosome();
            int[][][] mutations = new int[5][][];
            // copy to 5 mutaions
            for (var i = 0; i < 5; i++)
            {
                mutations[i] = new int[chromosome0.Length][];
                for (var j = 0; j < chromosome0.Length; j++)
                {
                    mutations[i][j] = new int[2] { chromosome0[j][0], chromosome0[j][1] };
                }
            }
            // apply 3-points permutation;
            int point1, point2, point3;
            point1 = this._rand.Next(0, chromosome0.Length - 1);

            do
            {
                point2 = this._rand.Next(0, chromosome0.Length - 1);
            } while (point2 == point1);

            do
            {
                point3 = this._rand.Next(0, chromosome0.Length - 1);
            } while (point3 == point2 || point3 == point1);
            mutations[0] = this._setGenePosition(chromosome0, mutations[0], point1, point2, point3, point1, point3, point2);
            mutations[1] = this._setGenePosition(chromosome0, mutations[1], point1, point2, point3, point2, point1, point3);
            mutations[2] = this._setGenePosition(chromosome0, mutations[2], point1, point2, point3, point2, point3, point1);
            mutations[3] = this._setGenePosition(chromosome0, mutations[3], point1, point2, point3, point3, point1, point2);
            mutations[4] = this._setGenePosition(chromosome0, mutations[4], point1, point2, point3, point3, point2, point1);

            // create 5 entities and choose the best one
            Entity[] candidates = new Entity[5];
            int minIndex = 0;
            double minFitness = Double.MaxValue;
            double currentFitness;

            for (var i = 0; i < 5; i++)
            {
                candidates[i] = new Entity(this._sbrp.NumBuses, mutations[i]);
                currentFitness = this._calculateFitness(candidates[i]);
                if (currentFitness < minFitness)
                {
                    minFitness = currentFitness;
                    minIndex = i;
                }
            }

            return candidates[minIndex];
        }

        private Entity _mutation6Case(Entity entity)
        {
            int[][] chromosome0 = entity.getChromosome();
            int[][][] mutations = new int[5][][];
            // copy to 5 mutaions
            for (var i = 0; i < 5; i++)
            {
                mutations[i] = new int[chromosome0.Length][];
                for (var j = 0; j < chromosome0.Length; j++)
                {
                    mutations[i][j] = new int[2] { chromosome0[j][0], chromosome0[j][1] };
                }
            }
            // apply 3-points permutation;
            int point1, point2, point3;
            point1 = this._rand.Next(0, chromosome0.Length - 1);

            do
            {
                point2 = this._rand.Next(0, chromosome0.Length - 1);
            } while (point2 == point1);

            do
            {
                point3 = this._rand.Next(0, chromosome0.Length - 1);
            } while (point3 == point2 || point3 == point1);
            mutations[0] = this._setGenePosition(chromosome0, mutations[0], point1, point2, point3, point1, point3, point2);
            mutations[1] = this._setGenePosition(chromosome0, mutations[1], point1, point2, point3, point2, point1, point3);
            mutations[2] = this._setGenePosition(chromosome0, mutations[2], point1, point2, point3, point2, point3, point1);
            mutations[3] = this._setGenePosition(chromosome0, mutations[3], point1, point2, point3, point3, point1, point2);
            mutations[4] = this._setGenePosition(chromosome0, mutations[4], point1, point2, point3, point3, point2, point1);

            // create 6 entities (5 new ones) and choose the best one
            Entity[] candidates = new Entity[6];
            candidates[0] = entity;
            int minIndex = 0;
            double minFitness = this._calculateFitness(entity);
            double currentFitness;

            for (var i = 0; i < 5; i++)
            {
                candidates[i + 1] = new Entity(this._sbrp.NumBuses, mutations[i]);
                currentFitness = this._calculateFitness(candidates[i + 1]);
                if (currentFitness < minFitness)
                {
                    minFitness = currentFitness;
                    minIndex = i + 1;
                }
            }

            return candidates[minIndex];
        }

        private int[][] _setGenePosition(int[][] chromosome0, int[][] chromosome, int i, int j, int k, int i1, int j1, int k1)
        {
            chromosome[i1][0] = chromosome0[i][0];
            chromosome[i1][1] = chromosome0[i][1];

            chromosome[j1][0] = chromosome0[j][0];
            chromosome[j1][1] = chromosome0[j][1];

            chromosome[k1][0] = chromosome0[k][0];
            chromosome[k1][1] = chromosome0[k][1];

            return chromosome;
        }
        /// <summary>
        /// Repair the entity
        /// </summary>
        /// <param name="entity"></param>
        private void _repair(Entity entity)
        {
            entity.optimizeBusStopOrders(this._sbrp.DistanceMatrix);
        }

        /// <summary>
        /// Select male and female parents from
        /// </summary>
        /// <param name="male"></param>
        /// <param name="female"></param>
        private void _selectTwoParents(ref Entity male, ref Entity female)
        {
            int maleIndex, femaleIndex;
            maleIndex = this._rand.Next(0, ((int)Math.Round(this.SelectionRatio * this.PopulationSize)));
            do
            {
                femaleIndex = this._rand.Next(0, this._population.CurrentPopulation - 1);
            } while (femaleIndex == maleIndex);
            male = this._population.getEntityAt(maleIndex);
            female = this._population.getEntityAt(femaleIndex);
        }

        /// <summary>
        /// Select one entity randomly from the current population
        /// </summary>
        /// <param name="ent"></param>
        private void _selectOneParent(ref Entity ent)
        {
            int index = this._rand.Next(0, this.PopulationSize - 1);
            ent = this._population.getEntityAt(index);
        }
        /// <summary>
        /// Calculate the fitness of each entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private double _calculateFitness(Entity entity)
        {
            var routeLengths = entity.getRouteLengths(this._sbrp.DistanceMatrix);
            return routeLengths.Sum();
        }

    }
}

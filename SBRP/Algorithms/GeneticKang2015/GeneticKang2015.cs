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
            this._updateElites();

            int generation = 0;
            this._output.printLine(String.Format("Generation: {0} - Best solution fitness {1}", generation, this._population.getBestFitness()));

            for(generation = 1; generation <= this.NumberOfGenerations; generation++)
            {
                this._output.printLine(String.Format("Generation: {0} - Best solution fitness {1}", generation, this._population.getBestFitness()));
            }

            r = this._rand.NextDouble();
        }

        private void _generateInitialPopulation()
        {
            this._population = new Population();
            while(this._population.CurrentPopulation < this.PopulationSize)
            {
                // Allocate buses to bus stops
                List<int> buses = Enumerable.Range(1, this._sbrp.NumBuses).ToList();
                List<int> busStops = Enumerable.Range(1, this._sbrp.NumBusStops).ToList();
                Entity entity = new Entity(this._sbrp.NumBuses, this._sbrp.BusStops.Length);
                int index, bus, busStop, busCapacity;
                double routeLength;

                index = this._rand.Next(0, buses.Count - 1);
                bus = buses[index];
                buses.RemoveAt(index);

                while(busStops.Count > 0)
                {
                    index = this._rand.Next(0, busStops.Count - 1);
                    busStop = busStops[index];
                    busStops.RemoveAt(index);

                    // check the bus capacity
                    busCapacity = 0;
                    routeLength = 0;
                    foreach(int bs in entity.getRoute(bus)) {
                        busCapacity += this._sbrp.BusStops[bs - 1].NumStudent;
                    }

                    // If the bus does not have enough seats, we randomly pick a new bus
                    if (busCapacity + this._sbrp.BusStops[busStop - 1].NumStudent > this._sbrp.VehicleCapacity)
                    {
                        index = this._rand.Next(0, buses.Count - 1);
                        bus = buses[index];
                        buses.RemoveAt(index);
                    }

                    entity.assignBusToBusStop(bus, busStop);
                }

                entity.sortBusStopsInRoutes(this._sbrp.DistanceMatrix);

                this._population.addEntity(entity.encode());

            }
        }

        /// <summary>
        /// Sort the population by the fitness
        /// </summary>
        private void _sort() {
            this._population.sortEntities(this._calculateFitness);
        }
        private void _updateElites() { }
        private void _crossover() { }
        private void _mutation5Case() { }
        private void _selectOneIndividual() { }
        private void _repair() { }

        /// <summary>
        /// Calculate the fitness of each entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        private double _calculateFitness(Entity entity)
        {
            var routeLengths = entity.getRouteLengths(this._sbrp.DistanceMatrix);
            double totalLength = 0;

            foreach(double l in routeLengths)
            {
                totalLength += l;

                if (l > this._sbrp.MaxRiddingTime)
                {
                    totalLength += (l - this._sbrp.MaxRiddingTime);
                }
            }

            return totalLength;
        }

    }
}

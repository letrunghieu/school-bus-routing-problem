using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SBRP.Algorithms.GeneticKang2015
{
    class Population
    {
        public int CurrentPopulation { get { return this._entities.Count; } }
        private List<Entity> _entities;

        public Population()
        {
            this._entities = new List<Entity>();
        }

        public void addEntity(Entity entity)
        {
            this._entities.Add(entity);
        }

        public void setEntityAt(int index, Entity entity)
        {
            this._entities[index] = entity;
        }

        /// <summary>
        /// Sort entities so that the one with the minimum fitness comes first
        /// </summary>
        /// <param name="fitnessFunc"></param>
        public void sortEntities(Func<Entity, double> fitnessFunc)
        {
            for (var i = 0; i < this._entities.Count; i++)
            {
                this._entities[i].Fitness = fitnessFunc(this._entities[i]);
            }

            this._entities.Sort((e1, e2) =>
            {
                if (e1.Fitness > e2.Fitness)
                {
                    return 1;
                }
                else if (e1.Fitness < e2.Fitness)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            });
        }

        public void updateElites(int num)
        {
            // reset the elitism
            foreach(Entity e in this._entities)
            {
                e.IsElite = false;
            }

            for(var i = 0; i < num; i++)
            {
                this._entities[i].IsElite = true;
            }
        }

        public double getBestFitness()
        {
            return this._entities[0].Fitness;
        }

        public string getBestSolutionRoutesLength(double[,] dmat)
        {
            return String.Join(",", this._entities[0].getRouteLengths(dmat).ToArray());
        }

        /// <summary>
        /// Get the entity at a position i
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Entity getEntityAt(int i)
        {
            return this._entities[i];
        }
    }
}

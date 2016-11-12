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
                    return -1;
                }
                else if (e1.Fitness < e2.Fitness)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });
        }
    }
}

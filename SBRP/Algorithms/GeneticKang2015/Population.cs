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
    }
}

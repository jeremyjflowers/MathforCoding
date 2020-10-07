using System;
using System.Collections.Generic;
using System.Text;

namespace MathForGames
{
    class Scene
    {
        private Entity[] _entities;
        
        public Scene()
        {
            _entities = new Entity[0];
        }

        public void AddEntity(Entity entity)
        {
            Entity[] appendedArray = new Entity[_entities.Length + 1];
            for(int i = 0; i < _entities.Length; i++)
            {
                appendedArray[i] = _entities[1];
            }
            appendedArray[_entities.Length] = entity;
            _entities = appendedArray;
        }

        public void Start()
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }

        public void End()
        {

        }
    }
}

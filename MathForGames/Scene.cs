using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Scene
    {
        private Entity[] _entities;

        public bool Started { get; private set; }

        public Scene()
        {
            _entities = new Entity[0];
        }

        public void AddEntity(Entity entity)
        {
            //Creating a new array with a size one greater than the orginal array
            Entity[] appendedArray = new Entity[_entities.Length + 1];
            //Copied values from orginal array to new array
            for(int i = 0; i < _entities.Length; i++)
            {
                appendedArray[i] = _entities[i];
            }
            //Sets the class value in the new array to be the entity we want to add
            appendedArray[_entities.Length] = entity;
            //Set old array to hold the values of the new array
            _entities = appendedArray;
        }

        public bool RemoveEntity(int index)
        {
            //Checks to see if the index is out of bonds of our array
            if(index < 0 || index >= _entities.Length)
            {
                return false;
            }

            bool entityRemoved = false;

            //Creating a new array with a size one less than the orginal array
            Entity[] newArray = new Entity[_entities.Length - 1];
            //Create new variable to access newArray index
            int j = 0;
            //Copy values from original array to the new array
            for(int i = 0; i < _entities.Length; i++)
            {
                //If the current index is not the index that needs to be removed, add the value into the old array and increment j
                if(i != index)
                {
                    newArray[j] = _entities[i];
                    j++;
                }
                else
                {
                    entityRemoved = true;
                    if (_entities[i].Started)
                        _entities[i].End();
                }
            }
            //Set the old array to be the newArray
            _entities = newArray;
            return entityRemoved;
        }

        public bool RemoveEntity(Entity entity)
        {
            //Checks to see if the entity is null
            if(entity == null)
            {
                return false;
            }

            bool entityRemoved = false;
            //Creating a new array with a size one less than the orginal array
            Entity[] newArray = new Entity[_entities.Length - 1];
            //Create new variable to access newArray index
            int j = 0;
            //Copy values from original array to the new array
            for (int i = 0; i < _entities.Length; i++)
            {
                //If the current index is not the index that needs to be removed, add the value into the old array and increment j
                if (entity != _entities[i])
                {
                    newArray[j] = _entities[i];
                    j++;
                }
                else
                {
                    entityRemoved = true;
                    if (entity.Started)
                        entity.End();
                }
            }
            //Set the old array to be the new array
            _entities = newArray;
            //Return wheter the removal was successful or not
            return entityRemoved;
        }


        /// <summary>
        /// Check to see if any entity has collied with anything
        /// </summary>
        private void CheckCollision()
        {

        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            for (int i = 0; i < _entities.Length; i++)
            {
                if(!_entities[i].Started)
                    _entities[i].Start();

                _entities[i].Update(deltaTime);
            }
            CheckCollision();
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _entities.Length; i++)
            {
                _entities[i].Draw();
            }
        }

        public virtual void End()
        {
            for (int i = 0; i < _entities.Length; i++)
            {
                if(!_entities[i].Started)
                    _entities[i].End();
            }

            Started = false;
        }
    }
}

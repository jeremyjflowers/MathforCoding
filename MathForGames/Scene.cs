using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;

namespace MathForGames
{
    class Scene
    {
        private Actor[] _actors;

        public bool Started { get; private set; }

        public Scene()
        {
            _actors = new Actor[0];
        }

        public void AddActor(Actor actor)
        {
            //Creating a new array with a size one greater than the orginal array
            Actor[] appendedArray = new Actor[_actors.Length + 1];
            //Copied values from orginal array to new array
            for(int i = 0; i < _actors.Length; i++)
            {
                appendedArray[i] = _actors[i];
            }
            //Sets the class value in the new array to be the entity we want to add
            appendedArray[_actors.Length] = actor;
            //Set old array to hold the values of the new array
            _actors = appendedArray;
        }

        public bool RemoveActor(int index)
        {
            //Checks to see if the index is out of bonds of our array
            if(index < 0 || index >= _actors.Length)
            {
                return false;
            }

            bool actorRemoved = false;

            //Creating a new array with a size one less than the orginal array
            Actor[] newArray = new Actor[_actors.Length - 1];
            //Create new variable to access newArray index
            int j = 0;
            //Copy values from original array to the new array
            for(int i = 0; i < _actors.Length; i++)
            {
                //If the current index is not the index that needs to be removed, add the value into the old array and increment j
                if(i != index)
                {
                    newArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    if (_actors[i].Started)
                        _actors[i].End();
                }
            }
            //Set the old array to be the newArray
            _actors = newArray;
            return actorRemoved;
        }

        public bool RemoveActor(Actor actor)
        {
            //Checks to see if the entity is null
            if(actor == null)
            {
                return false;
            }

            bool actorRemoved = false;
            //Creating a new array with a size one less than the orginal array
            Actor[] newArray = new Actor[_actors.Length - 1];
            //Create new variable to access newArray index
            int j = 0;
            //Copy values from original array to the new array
            for (int i = 0; i < _actors.Length; i++)
            {
                //If the current index is not the index that needs to be removed, add the value into the old array and increment j
                if (actor != _actors[i])
                {
                    newArray[j] = _actors[i];
                    j++;
                }
                else
                {
                    actorRemoved = true;
                    if (actor.Started)
                        actor.End();
                }
            }
            //Set the old array to be the new array
            _actors = newArray;
            //Return wheter the removal was successful or not
            return actorRemoved;
        }


        /// <summary>
        /// Check to see if any entity has collied with anything
        /// </summary>
        private void CheckCollision()
        {
            for (int i = 0; i < _actors.Length; i++)

            {

                for (int j = 0; j < _actors.Length; j++)

                {

                    if (i >= _actors.Length)

                        break;



                    if (_actors[i].CheckCollision(_actors[j]) && i != j)

                        _actors[i].OnCollision(_actors[j]);

                }

            }
        }

        public virtual void Start()
        {
            Started = true;
        }

        public virtual void Update(float deltaTime)
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if(!_actors[i].Started)
                    _actors[i].Start();

                _actors[i].Update(deltaTime);
            }
            CheckCollision();
        }

        public virtual void Draw()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                _actors[i].Draw();
            }
        }

        public virtual void End()
        {
            for (int i = 0; i < _actors.Length; i++)
            {
                if(!_actors[i].Started)
                    _actors[i].End();
            }

            Started = false;
        }
    }
}

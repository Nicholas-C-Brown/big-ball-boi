using Godot;
using System;

namespace BigBallBoiGame.State
{

    public abstract partial class State<T> : Node where T: Node
    {

        public T Parent { get; set; }

        /// <summary>
        /// Called when this state is swapped to from another state.
        /// Used to call one time actions when entering the state.
        /// </summary>
        public virtual void Enter()
        {

        }

        /// <summary>
        /// Called right when this state is about to be swapped to another state. 
        /// Used to cleanup resources before swapping states.
        /// </summary>
        public virtual void Exit()
        {

        }

        /// <summary>
        /// Processes user input for the current state
        /// </summary>
        /// <param name="input">Input Event to be processed</param>
        /// <returns>The next state to transition to, or null if the state has not changed.</returns>
        public virtual State<T>? ProcessInput(InputEvent input)
        {
            return null;
        }

        /// <summary>
        /// Processes frame updates for the current state
        /// </summary>
        /// <param name="delta">Time since the last frame.</param>
        /// <returns>The next state to transition to, or null if the state has not changed.</returns>
        public virtual State<T>? ProcessFrame(float delta)
        {
            return null;
        }

        /// <summary>
        /// Processes physics updates for the current state
        /// </summary>
        /// <param name="delta">Time since the last frame.</param>
        /// <returns>The next state to transition to, or null if the state has not changed.</returns>
        public virtual State<T>? ProcessPhysics(float delta)
        {
            return null;
        }

    }

}



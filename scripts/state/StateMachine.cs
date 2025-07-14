using Godot;
using System;
using System.Collections.Generic;
using System.Linq;


namespace BigBallBoiGame.State
{

    /// <summary>
    /// Node component for handling object states
    /// </summary>
    public abstract partial class StateMachine<T> : Node where T : Node
    {

        [Export]
        private State<T> startingState;

        private State<T> currentState;


        public void Initialize(T parent)
        {
            ArgumentNullException.ThrowIfNull(startingState);

            //Find all child state nodes
            List<State<T>> childStates = GetChildren()
                .OfType<State<T>>()
                .ToList();

            foreach (State<T> childState in childStates)
            {
                childState.Parent = parent;
            }

            ChangeState(startingState);
        }

        /// <summary>
        /// Changes the State Machine's current state.<br/>
        /// First calls Exit() on the previous state and Enter() on the new state.
        /// </summary>
        /// <param name="newState"></param>
        public void ChangeState(State<T> newState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }

            currentState = newState;
            currentState.Enter();

        }

        /// <summary>
        /// Pass through function for _UnhandledInput().<br/>
        /// Handles state changes as needed.
        /// </summary>
        /// <param name="input">Input event</param>
        public void ProcessInput(InputEvent input)
        {
            State<T>? newState = currentState.ProcessInput(input);
            if (newState != null)
            {
                ChangeState(newState);
            }
        }

        /// <summary>
        /// Pass through function for _Process().<br/>
        /// Handles state changes as needed.
        /// </summary>
        /// <param name="input">Input event</param>
        public void ProcessFrame(float delta)
        {
            State<T>? newState = currentState.ProcessFrame(delta);
            if (newState != null)
            {
                ChangeState(newState);
            }
        }

        /// <summary>
        /// Pass through function for _PhysicsProcess().<br/>
        /// Handles state changes as needed.
        /// </summary>
        /// <param name="input">Input event</param>
        public void ProcessPhysics(float delta)
        {
            State<T>? newState = currentState.ProcessPhysics(delta);
            if (newState != null)
            {
                ChangeState(newState);
            }
        }

    }
}

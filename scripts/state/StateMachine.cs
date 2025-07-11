using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Node component for handling object states
/// </summary>
public partial class StateMachine : Node
{

    [Export]
    private State startingState;

    private State? currentState;


    public void Initialize(ComponentProvider provider)
    {
        ArgumentNullException.ThrowIfNull(startingState);
        ArgumentNullException.ThrowIfNull(provider);

        //Find all child state nodes
        List<State> childStates = GetChildren()
            .OfType<State>()
            .ToList();

        foreach (State childState in childStates)
        {
            childState.ComponentProvider = provider;
            childState.Initialize();
        }

        ChangeState(startingState);

    }

    /// <summary>
    /// Changes the State Machine's current state.<br/>
    /// First calls Exit() on the previous state and Enter() on the new state.
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(State newState)
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



        State? newState = currentState.ProcessInput(input);
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
        State? newState = currentState.ProcessFrame(delta);
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
        State? newState = currentState.ProcessPhysics(delta);
        if (newState != null)
        {
            ChangeState(newState);
        }
    }

}

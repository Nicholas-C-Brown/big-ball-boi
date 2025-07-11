using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class ComponentProvider : Node
{

    //Components
    [Export] private Node[] components;

    private Node? parent;

    public T GetParentComponent<T>()
    {

        if (parent == null)
        {
            parent = GetParent();
        }

        ArgumentNullException.ThrowIfNull(parent);
        
        if(parent is T parentComponent)
        {
            return parentComponent;
        }

        throw new ArgumentException("Parent is not of type " + typeof(T));
    }

    public T GetRequiredComponent<T>()
    {
        T? component = GetOptionalComponent<T>();

        if(component == null)
        {
            throw new ArgumentNullException("Required component " +  typeof(T) + " was not found");
        }

        return component;
    }

    public T? GetOptionalComponent<T>()
    {
        foreach (var component in components)
        {
            if (component is T found)
            {
                return found;
            }
        }

        return default;
    }

}


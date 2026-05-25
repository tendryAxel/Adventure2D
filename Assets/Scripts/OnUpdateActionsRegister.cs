using System;
using System.Collections.Generic;

public class OnUpdateActionsRegister <T>
{
    private List<Action<T>> onUpdateActions = new();

    public void Clear()
    {
        onUpdateActions.Clear();
    }

    public void Update (T context)
    {
        foreach (Action<T> action in onUpdateActions)
        {
            action(context);
        }
    }

    public void RegisterOnUpdateActions(Action<T> action)
    {
        onUpdateActions.Add(action);
    }
}

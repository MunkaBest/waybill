using System;
using System.Collections.Generic;

public interface ICarsHolder
{
    public event Action<Dictionary<string, object>> OnReceived;
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IView
{
    void Setup(Dictionary<string, object> payload);
}

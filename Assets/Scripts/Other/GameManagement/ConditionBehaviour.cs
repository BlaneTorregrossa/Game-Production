using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionBehaviour : MonoBehaviour
{
    public FloatVariable var1;
    public OperatorVariable op;
    public FloatVariable var2;
    public GameEvent gameEvent;

    void Update()
    {
        if(op.Evaluate(var1.Value, var2.Value))
        {
            gameEvent.Raise();
        }
    }
}

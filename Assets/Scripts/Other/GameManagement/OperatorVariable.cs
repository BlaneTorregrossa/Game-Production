using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OperatorVariable : ScriptableObject
{
    public enum Operator
    {
        NONE,
        LESS,
        GREATER,
        GREATEREQUAL,
        LESSEQUAL,
        EQUAL
    }

    public Operator op = Operator.NONE;

    public bool Evaluate(float arg1, float arg2)
    {
        bool result;
        switch (op)
        {
            case Operator.NONE:
                throw new System.Exception("You need to assign two float variables");
            case Operator.LESS:
                {
                    result = arg1 < arg2;
                    break;
                }

            case Operator.GREATER:
                {
                    result = arg1 > arg2;
                    break;
                }

            case Operator.GREATEREQUAL:
                {
                    result = arg1 >= arg2;
                    break;
                }
            case Operator.LESSEQUAL:
                {
                    result = arg1 <= arg2;
                    break;
                }
            case Operator.EQUAL:
                {
                    result = arg1 == arg2;
                    break;
                }
            default:
                throw new ArgumentOutOfRangeException();
        }
        return result;
    }
}

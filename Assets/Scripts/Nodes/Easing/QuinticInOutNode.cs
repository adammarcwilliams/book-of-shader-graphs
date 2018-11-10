using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Quintic In Out")]
public class QuinticInOutNode : CodeFunctionNode
{

    public QuinticInOutNode()
    {
        name = "Quintic In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("QuinticInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string QuinticInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    if (T < 0.5)
    {
        Out = 16 * pow(T, 5.0);    
    }
    else
    {
        float f = ((2.0 * T) - 2.0);
        Out = (0.5 * pow(f, 5.0)) + 1; 
    }
}
";
    }
}

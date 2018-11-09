using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Quintic Out")]
public class QuinticOutNode : CodeFunctionNode
{

    public QuinticOutNode()
    {
        name = "Quintic Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("QuinticOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string QuinticOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = 1.0 - (pow(T - 1.0, 5.0));
}
";
    }
}

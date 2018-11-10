using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Circular Out")]
public class CircularOutNode : CodeFunctionNode
{

    public CircularOutNode()
    {
        name = "Circular Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("CircularOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string CircularOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = sqrt((2.0 - T) * T);
}
";
    }
}

using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Exponential In")]
public class ExponentialInNode : CodeFunctionNode
{

    public ExponentialInNode()
    {
        name = "Exponential In";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("ExponentialIn",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string ExponentialIn(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = (T == 0.0) ? T : pow(2.0, 10.0 * (T - 1.0));
}
";
    }
}

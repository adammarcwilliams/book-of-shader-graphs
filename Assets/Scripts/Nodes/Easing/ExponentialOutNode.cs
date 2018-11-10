using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Exponential Out")]
public class ExponentialOutNode : CodeFunctionNode
{

    public ExponentialOutNode()
    {
        name = "Exponential Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("ExponentialOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string ExponentialOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = (T == 1.0) ? T : 1.0 - pow(2.0, -10.0 * T);
}
";
    }
}

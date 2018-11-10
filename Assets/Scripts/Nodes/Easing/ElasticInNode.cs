using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Elastic In")]
public class ElasticInNode : CodeFunctionNode
{

    public ElasticInNode()
    {
        name = "Elastic In";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("ElasticIn",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string ElasticIn(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = sin(13.0 * HALF_PI * T) * pow(2.0, 10.0 * (T - 1.0));
}
";
    }
}

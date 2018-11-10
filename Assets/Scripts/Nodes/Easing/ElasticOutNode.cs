using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Elastic Out")]
public class ElasticOutNode : CodeFunctionNode
{

    public ElasticOutNode()
    {
        name = "Elastic Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("ElasticOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string ElasticOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    Out = sin(-13.0 * HALF_PI * (T + 1.0)) * pow(2.0, -10.0 * T) + 1.0;
}
";
    }
}

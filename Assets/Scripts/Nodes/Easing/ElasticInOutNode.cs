using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Elastic In Out")]
public class ElasticInOutNode : CodeFunctionNode
{

    public ElasticInOutNode()
    {
        name = "Elastic In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("ElasticInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string ElasticInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    if(T < 0.5)
	{
		Out = 0.5 * sin(13.0 * HALF_PI * (2.0 * T)) * pow(2.0, 10.0 * ((2.0 * T) - 1.0));
	}
	else
	{
		Out = 0.5 * (sin(-13.0 * HALF_PI * ((2.0 * T - 1.0) + 1.0)) * pow(2.0, -10.0 * (2.0 * T - 1.0)) + 2.0);
	}
}
";
    }
}

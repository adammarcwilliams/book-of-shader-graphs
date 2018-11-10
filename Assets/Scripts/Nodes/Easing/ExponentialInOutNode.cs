using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Exponential In Out")]
public class ExponentialInOutNode : CodeFunctionNode
{

    public ExponentialInOutNode()
    {
        name = "Exponential In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("ExponentialInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string ExponentialInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    if(T == 0.0 || T == 1.0) Out = T;
	
	if(T < 0.5)
	{
		Out = 0.5 * pow(2.0, (20.0 * T) - 10.0);
	}
	else
	{
		Out = -0.5 * pow(2.0, (-20.0 * T) + 10.0) + 1.0;
	}
}
";
    }
}

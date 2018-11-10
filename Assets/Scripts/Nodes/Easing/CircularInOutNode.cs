using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Circular In Out")]
public class CircularInOutNode : CodeFunctionNode
{

    public CircularInOutNode()
    {
        name = "Circular In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("CircularInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string CircularInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    if(T < 0.5)
	{
		Out = 0.5 * (1.0 - sqrt(1.0 - 4.0 * (T * T)));
	}
	else
	{
		Out = 0.5 * (sqrt(-((2.0 * T) - 3.0) * ((2.0 * T) - 1.0)) + 1.0);
	}
}
";
    }
}

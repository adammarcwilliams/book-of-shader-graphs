using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Back In Out")]
public class BackInOutNode : CodeFunctionNode
{

    public BackInOutNode()
    {
        name = "Back In Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("BackInOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string BackInOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    if(T < 0.5)
	{
		float f = 2.0 * T;
		Out = 0.5 * (f * f * f - f * sin(f * PI));
	}
	else
	{
		float f = (1.0 - (2.0 * T - 1.0));
		Out = 0.5 * (1.0 - (f * f * f - f * sin(f * PI))) + 0.5;
	}
}
";
    }
}

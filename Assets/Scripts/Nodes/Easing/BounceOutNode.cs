using UnityEngine;
using UnityEditor.ShaderGraph;
using System.Reflection;

[Title("Eases", "Bounce Out")]
public class BounceOutNode : CodeFunctionNode
{

    public BounceOutNode()
    {
        name = "Bounce Out";
    }

    protected override MethodInfo GetFunctionToConvert()
    {
        return GetType().GetMethod("BounceOut",
            BindingFlags.Static | BindingFlags.NonPublic);
    }

    static string BounceOut(
        [Slot(0, Binding.None)] DynamicDimensionVector T,
        [Slot(1, Binding.None)] out DynamicDimensionVector Out)
    {
        return
            @"
{
    if(T < 4.0/11.0)
	{
		Out = (121.0 * T * T)/16.0;
	}
	else if(T < 8.0/11.0)
	{
		Out = (363.0/40.0 * T * T) - (99.0/10.0 * T) + 17.0/5.0;
	}
	else if(T < 9.0/10.0)
	{
		Out = (4356.0/361.0 * T * T) - (35442.0/1805.0 * T) + 16061.0/1805.0;
	}
	else
	{
		Out = (54.0/5.0 * T * T) - (513.0/25.0 * T) + 268.0/25.0;
    }
}
";
    }
}

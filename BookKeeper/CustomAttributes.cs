using System;
using System.ComponentModel;
using System.Diagnostics;

namespace BookKeeper
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    [Description("Specifies whether a method is not working correctly. This class can be inherited.")]
    internal class NotWorkingCorrectlyAttribute : Attribute
    {
#if !DEBUG
#warning Check if you have methods with the NotWorkingCorrectly attribute that need to be fixed before release.
#endif
    }

    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    [Description("Specifies whether a method needs performance improvements. This class can be inherited.")]
    internal class NeedsPerformanceImprovement : Attribute
    {
#if !DEBUG
#warning Check if you have methods with the NeedsPerformanceImprovement attribute before release.
#endif
    }

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true)]
    [Description("Specifies whether a method or class is incomplete. This class can be inherited.")]
    internal class Incomplete : Attribute
    {
#if !DEBUG
#warning Check if you have methods with the Incomplete attribute before release.
#endif
    }

}
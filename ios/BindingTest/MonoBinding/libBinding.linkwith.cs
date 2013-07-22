using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("libBinding.a", LinkTarget.Simulator, ForceLoad = true)]

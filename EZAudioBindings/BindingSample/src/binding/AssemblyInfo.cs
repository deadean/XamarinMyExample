using System;
using ObjCRuntime;

[assembly: LinkWith ("libXMBindingLibrarySampleUniversal.a", LinkTarget.Simulator | LinkTarget.ArmV6 | LinkTarget.ArmV7 | LinkTarget.Arm64 | LinkTarget.Simulator64, Frameworks = "QuartzCore UIKit Foundation Accelerate", LinkerFlags="-lxml2 -ObjC", ForceLoad = true)]
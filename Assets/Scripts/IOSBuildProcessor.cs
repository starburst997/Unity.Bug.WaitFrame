#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEditor.iOS.Xcode;
using UnityEngine;

namespace Editor.Player.Build
{
    // Fix some `plist` properties, not sure if there is now a way to do it without code...
    public class IOSBuildProcessor : IPostprocessBuildWithReport
    {
        public int callbackOrder => 2;
        
        public void OnPostprocessBuild(BuildReport report)
        {
            if (report.summary.platform == BuildTarget.iOS) // Check if the build is for iOS 
            {
                // Rewrite "UnityAppController+Rendering.mm" to fix default fps to max
                var filePath = $"{report.summary.outputPath}/Classes/UnityAppController+Rendering.mm";
                var file = File.ReadAllText(filePath);
                
                var replace = @"targetFPS = UnityGetTargetFPS();";
                var with = @"targetFPS = maxFPS;";
                file = file.Replace(replace, with);
                
                File.WriteAllText(filePath, file);
                
                // Rewrite "MetalHelper.mm" to fix default fps to 60
                filePath = $"{report.summary.outputPath}/Classes/Unity/MetalHelper.mm";
                file = File.ReadAllText(filePath);
                
                replace = @"#if (PLATFORM_IOS || PLATFORM_TVOS) && !(TARGET_IPHONE_SIMULATOR || TARGET_TVOS_SIMULATOR)";
                with = @"#if NEVER_EVER";
                file = file.Replace(replace, with);
                
                File.WriteAllText(filePath, file);
            }
        }
    }
}
#endif
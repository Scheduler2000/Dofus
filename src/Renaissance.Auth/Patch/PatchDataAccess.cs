using System;
using System.IO;
using Renaissance.Abstract;

namespace Renaissance.Auth.Patch
{
    public static class PatchDataAccess
    {
        public static byte[] PatchBuffer { get; }

        static PatchDataAccess()
        {
            var path = Path.Combine(Environment.CurrentDirectory, @"SWF\AuthPatch.swf");

            if (File.Exists(path))
                PatchBuffer = File.ReadAllBytes(path);
            else
                Logger.Instance.Log(LogLevel.Fatal, "AUTH PATCH", $"Authentication patch not found : {path}");
        }
    }
}

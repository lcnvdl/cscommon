using System.IO;
using System.Reflection;

namespace Common.IO
{
    public static class Embedded
    {
        private static void CopyEmbeddedResources(this Assembly assembly, string outputDir, string resourceLocation, params string[] files)
        {
            foreach (string file in files)
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceLocation + @"." + file))
                {
                    using (FileStream fileStream = new FileStream(Path.Combine(outputDir, file), FileMode.Create))
                    {
                        for (int i = 0; i < stream.Length; i++)
                        {
                            fileStream.WriteByte((byte)stream.ReadByte());
                        }
                        fileStream.Close();
                    }
                }
            }
        }
    }
}

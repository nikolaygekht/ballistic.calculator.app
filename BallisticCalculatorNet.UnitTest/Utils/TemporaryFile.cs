using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallisticCalculatorNet.UnitTest.Utils
{
    internal class TemporaryFile : IDisposable
    {
        public static TemporaryFile New() => new TemporaryFile(Path.GetTempFileName());

        public static TemporaryFile WithExtension(string extension) => new TemporaryFile(Path.GetTempFileName() + "." + extension);

        public static TemporaryFile WithName(string name) => new TemporaryFile(name);

        private TemporaryFile(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }

        ~TemporaryFile()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            File.Delete(FileName);
        }

        public static TemporaryFile FromResource(string resourceId, string extension = null)
        {
            using var rs = typeof(TemporaryFile).Assembly.GetManifestResourceStream($"BallisticCalculatorNet.UnitTest.Resources.{resourceId}");
            if (rs == null)
                throw new ArgumentException($"Resources {resourceId} isn't found");
            var tf = extension == null ? New() : WithExtension(extension);
            using var ts = new FileStream(tf.FileName, FileMode.Create, FileAccess.Write, FileShare.None);
            rs.CopyTo(ts);
            return tf;
        }
    }
}

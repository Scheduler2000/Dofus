using System.IO;
using Renaissance.Data.D2I;

namespace Renaissance.WorldEditor.D2I
{
    public class D2IManager
    {
        private readonly string m_uriFile;
        private readonly D2IReader m_reader;

        public D2IDataAccess DataAccess { get; private set; }

        public D2IManager(string uriFile)
        {
            if (!File.Exists(uriFile))
                throw new FileNotFoundException($"File : {uriFile} doesn't exists !");

            this.m_uriFile = uriFile;
            this.m_reader = new D2IReader(File.ReadAllBytes(uriFile));
        }

        public void Load()
        {
            m_reader.Read(out var entries, out var uiEntries);
            DataAccess = new D2IDataAccess(entries, uiEntries);
        }

        public void Save()
        {
            byte[] data = m_reader.Save(DataAccess.Entries, DataAccess.UIEntries);

            File.Delete(m_uriFile);
            File.WriteAllBytes(m_uriFile, data);
        }

    }
}

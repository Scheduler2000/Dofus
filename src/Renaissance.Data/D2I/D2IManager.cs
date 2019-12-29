using System.IO;

namespace Renaissance.Data.D2I
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
            m_reader.Read(out var entries, out var uiEntries, out var sortedIndex);
            DataAccess = new D2IDataAccess(entries, uiEntries, sortedIndex);
        }

        public void Save()
        {
            var recorder = new D2IWriter(DataAccess.Entries, DataAccess.UIEntries, DataAccess.SortedIndex);

            byte[] data = recorder.Write();

            File.Delete(m_uriFile);
            File.WriteAllBytes(m_uriFile, data);
        }

    }
}

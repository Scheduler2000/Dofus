namespace Renaissance.Data.D2P
{
    public class DlmEntry
    {
        public string Name { get; }

        public int StartPosition { get; }

        public int BytesCount { get; }


        public DlmEntry(string dlmName, int startPosition, int bytesCount)
        {
            this.Name = dlmName;
            this.StartPosition = startPosition;
            this.BytesCount = bytesCount;
        }
    }
}

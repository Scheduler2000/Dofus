namespace Renaissance.Data.D2I
{
    public class D2IEntry
    {
        public string Text { get; set; }

        public bool UseUndiactricalText { get; set; }

        public string UnDiactricialText { get; set; }


        public D2IEntry(string text)
        { Text = text; }

        public D2IEntry(string text, string undiactricalText)
        {
            Text = text;
            UnDiactricialText = undiactricalText;
            UseUndiactricalText = true;
        }

    }
}

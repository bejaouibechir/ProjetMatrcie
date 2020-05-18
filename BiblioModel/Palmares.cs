namespace BiblioModel
{
    public class Palmares
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int Year { get; set; }
        public Author Author { get; set; }

        public override string ToString()
        {
            return $"{Year}:{Label}";
        }

    }
}
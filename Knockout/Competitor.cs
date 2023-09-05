namespace Knockout
{
    internal class Competitor
    {
        private string _name;

        public Competitor(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }
    }
}

using System.Data;

namespace PayRoll.Core.Model.Utility
{
    public class Parameter
    {
        public string Name { get; set; }
        public object Value { get; set; }
        public DbType Type { get; set; }
    }
}

using System.Collections.Generic;

namespace PayRoll.Core.Model.Utility
{
    public class DataCommon
    {
        public DbContext _dbContext;
        public List<Parameter> _inputParameters;
        public List<Parameter> _outputParameters;
        public string _query;

        public DataCommon()
        {
            _inputParameters = new List<Parameter>();
            _outputParameters = new List<Parameter>();
        }
    }
}

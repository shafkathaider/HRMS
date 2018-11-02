using System;
using System.Collections.Generic;
using System.Data;

namespace PayRoll.Core.Model.Utility
{
    public class DtConverter<T> where T : class, new()
    {
        public static List<T> ConvertToObject(DataTable dataTable)
        {
            var lst = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                var obj = new T();
                foreach (var prop in obj.GetType().GetProperties())
                {
                    var type = prop.PropertyType;

                    if (row.Table.Columns.Contains(prop.Name))
                    {
                        if (DBNull.Value != row[prop.Name])
                        {
                            if (type == typeof(Int32))
                            {
                                prop.SetValue(obj, Convert.ToInt32(row[prop.Name]));
                            }

                            if (type == typeof(string))
                            {
                                prop.SetValue(obj, Convert.ToString(row[prop.Name]));
                            }

                            if (type == typeof(bool))
                            {
                                if (row[prop.Name].ToString().ToUpper() == "TRUE" ||
                                    row[prop.Name].ToString().ToUpper() == "FALSE")
                                {
                                    prop.SetValue(obj, Convert.ToBoolean(row[prop.Name]));
                                }
                                else if (row[prop.Name].ToString() == "0" ||
                                    row[prop.Name].ToString() == "1")
                                {
                                    prop.SetValue(obj, Convert.ToBoolean(Convert.ToInt32(row[prop.Name])));
                                }
                            }
                            if (type == typeof(decimal))
                            {
                                prop.SetValue(obj, Convert.ToDecimal(row[prop.Name]));
                            }
                            if (type == typeof(DateTime))
                            {
                                prop.SetValue(obj, Convert.ToDateTime(row[prop.Name]));
                            }
                        }
                    }
                }
                lst.Add(obj);
            }
            return lst;
        }
    }
}

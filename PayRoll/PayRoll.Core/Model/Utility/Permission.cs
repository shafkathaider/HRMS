﻿using System;
using System.Data;

namespace PayRoll.Core.Model.Utility
{
    public class Permission
    {
        public string CanSave { set; get; }
        public string CanUpdate { set; get; }
        public string CanDelete { set; get; }

        public static Permission ConvertToModel(DataRow row)
        {
            return new Permission
            {
                CanSave = row.Table.Columns.Contains("CanSave") ? Convert.ToString(row["CanSave"]) : "",
                CanUpdate = row.Table.Columns.Contains("CanUpdate") ? Convert.ToString(row["CanUpdate"]) : "",
                CanDelete = row.Table.Columns.Contains("CanDelete") ? Convert.ToString(row["CanDelete"]) : "",
            };

        }

    }
}

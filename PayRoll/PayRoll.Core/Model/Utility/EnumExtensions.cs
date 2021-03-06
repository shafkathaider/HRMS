﻿using System;
using System.ComponentModel;

namespace PayRoll.Core.Model.Utility
{
    public static class EnumExtensions
    {
        public static string Description(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var field = enumType.GetField(enumValue.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length == 0
                            ? enumValue.ToString()
                            : ((DescriptionAttribute)attributes[0]).Description;

        }
    }
}

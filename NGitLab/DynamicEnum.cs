﻿using System;
using System.Collections.Generic;

namespace NGitLab
{
    /// <summary>
    /// Allows to expose enums without knowing all the possible values
    /// that can be serialized from the client.
    /// </summary>
    public struct DynamicEnum<TEnum> : IEquatable<DynamicEnum<TEnum>>, IEquatable<TEnum>
        where TEnum : Enum
    {
        /// <summary>
        /// This value is filled when the value is recognized.
        /// </summary>
        private TEnum EnumValue { get; }

        /// <summary>
        /// Contains the serialized string when the value is not a known
        /// flag of the underlying enum.
        /// </summary>
        public string StringValue { get; }

        public DynamicEnum(TEnum enumValue)
        {
            EnumValue = enumValue;
            StringValue = null;
        }

        public DynamicEnum(string stringValue)
        {
            EnumValue = default;
            StringValue = stringValue;
        }

        public bool Equals(TEnum other)
        {
            return Equals(EnumValue, other);
        }

        public bool Equals(DynamicEnum<TEnum> other)
        {
            return EqualityComparer<TEnum>.Default.Equals(EnumValue, other.EnumValue);
        }

        public override bool Equals(object obj)
        {
            return obj is DynamicEnum<TEnum> other && Equals(other);
        }

        public override int GetHashCode()
        {
            return EqualityComparer<TEnum>.Default.GetHashCode(EnumValue);
        }

        public static bool operator ==(DynamicEnum<TEnum> obj1, DynamicEnum<TEnum> obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(DynamicEnum<TEnum> obj1, DynamicEnum<TEnum> obj2)
        {
            return !obj1.Equals(obj2);
        }

        public static bool operator ==(DynamicEnum<TEnum> obj1, TEnum obj2)
        {
            return obj1.Equals(obj2);
        }

        public static bool operator !=(DynamicEnum<TEnum> obj1, TEnum obj2)
        {
            return !obj1.Equals(obj2);
        }

        public override string ToString()
        {
            return StringValue ?? EnumValue.ToString();
        }
    }
}
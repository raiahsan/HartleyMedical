﻿using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HartleyMedical.Application.Common.Helpers
{
    public static class StringExtensions
    {
        private static readonly FileExtensionContentTypeProvider Provider = new FileExtensionContentTypeProvider();

        public static string GetContentType(this string fileName)
        {
            if (!Provider.TryGetContentType(fileName, out var ContentType))
            {
                ContentType = "application/octet-stream";
            }

            return ContentType;
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return !string.IsNullOrEmpty(value);
        }
        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        public static string RemoveSpecialCharacters(this string value)
        {
            return Regex.Replace(value ?? "", @"[-() +]+", "");
        }

        public static string ToPhoneNumberFormat(this string value)
        {
            return Convert.ToInt64(value?.RemoveSpecialCharacters() ?? "").ToString("+0 (0##) ###-####");
        }

        public static string ToHL7PhoneNumberFormat(this string value)
        {
            var phonenumber = value?.RemoveSpecialCharacters() ?? "";
            if (phonenumber?.Length > 10)
            {
                // remove country code
                phonenumber = phonenumber.Substring(phonenumber.Length - 10);
            }
            return Convert.ToInt64(phonenumber).ToString("(0##)###-####");
        }

        public static string ToSSNFormat(this string value)
        {
            return Convert.ToInt64(value?.RemoveSpecialCharacters() ?? "").ToString("0#-##-####");
        }

        public static bool IsPhoneNumber(this string value)
        {
            return Regex.IsMatch(value?.RemoveSpecialCharacters() ?? "", @"^[0-9]{10}$");
        }

        public static bool IsSSN(this string value)
        {
            return Regex.IsMatch(value?.RemoveSpecialCharacters() ?? "", @"^[0-9]{9}$");
        }

    }
}

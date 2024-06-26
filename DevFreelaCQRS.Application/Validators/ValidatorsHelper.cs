﻿using System.Text.RegularExpressions;

namespace DevFreelaCQRS.Application.Validators
{
    public static class ValidatorsHelper
    {
        public static bool IsPasswordValid(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");
            return regex.IsMatch(password);
        }

        public static bool IsAValidDate(DateTime date)
        {
            var now = DateTime.Now;
            return date.Year <= now.Year && date != DateTime.MinValue;
        }

        public static bool IsValidGuid(Guid guid) => Guid.TryParse(guid.ToString(), out _);

    }
}

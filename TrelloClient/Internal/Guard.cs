using System;
using System.Text.RegularExpressions;
using TrelloClient.Models;

namespace TrelloClient.Internal
{
    internal static class Guard
    {
        public static void NotNull(object parameter, string parameterName)
        {
            if (parameter == null)
                throw new ArgumentNullException(parameterName);
        }

        public static void NotNullOrEmpty(string parameter, string parameterName)
        {
            if (parameter == null)
                throw new ArgumentNullException(parameterName);
            if (parameter == string.Empty)
                throw new ArgumentException($"Parameter {parameterName} is empty.", parameterName);
        }

        public static void LengthBetween(string parameter, int min, int max, string parameterName)
        {
            NotNull(parameter, parameterName);
            if (parameter.Length < min || parameter.Length > max)
                throw new ArgumentOutOfRangeException(parameterName, parameter.Length, $"Length of string parameter {parameterName} is out of range (must be between {min} and {max})");
        }

        public static void OptionalTrelloString(string parameter, string parameterName)
        {
            LengthBetween(parameter, 0, 16384, parameterName);
        }

        public static void RequiredTrelloString(string parameter, string parameterName)
        {
            LengthBetween(parameter, 1, 16384, parameterName);
        }

        public static void MatchesLongId(BoardId id) => MatchesLongId(id, parameterName: "boardId");
        public static void MatchesLongId(CardId id) => MatchesLongId(id, parameterName: "cardId");
        public static void MatchesShortId(CardShortId id) => MatchesShortId(id, parameterName: "cardShortId");
        public static void MatchesShortId(BoardShortId id) => MatchesShortId(id, parameterName: "boardShortId");
        public static void MatchesLongId(AttachmentId id) => MatchesLongId(id, parameterName: "AttachmentId");
        public static void MatchesLongId(BoardListId id) => MatchesLongId(id, parameterName: "listId");

        public static void MatchesLongId(string id, string parameterName)
        {
            NotNullOrEmpty(id, parameterName);
            if (!Regex.IsMatch(id, @"^[0-9a-fA-F]{24}$"))
            {
                throw new ArgumentException($"Parameter {parameterName} is not 24 characters or does not match pattern", parameterName);
            }
        }
        public static void MatchesShortId(string id, string parameterName)
        {
            NotNullOrEmpty(id, parameterName);
            if (!Regex.IsMatch(id, @"^[0-9a-zA-Z]{8}$"))
            {
                throw new ArgumentException($"Parameter {parameterName} is not 8 characters or does not match pattern", parameterName);
            }
        }
    }
}

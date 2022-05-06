namespace WordLadderBusiness.Validators
{
    public static class ArgumentsValidator
    {
        /// <summary>
        /// Validate if the Word is Valid
        /// </summary>
        /// <param name="word"></param>
        /// <param name="argumentIdentifier"></param>
        /// <returns></returns>
        public static bool IsWordValid(string? word, string? argumentIdentifier = null)
        {
            bool result = false;
            if (word != null && word.Length == 4 && !word.Contains(' '))
            {
                result = true;
            }
            else
            {
                var errorString = "Not a valid input, it shall be 4 chars long and contain no empty space.";
                Console.Clear();
                Console.WriteLine($"ERROR: {(string.IsNullOrEmpty(argumentIdentifier) ? "" : $"(In argument {argumentIdentifier})")} {errorString}");
                Console.WriteLine();
            }           

            return result;
        }

        public static bool IsFilePathValid(string? path, string? argumentIdentifier = null)
        {
            bool result = File.Exists(path);

            if (!result)
            {
                var errorString = "The file is not valid or not accessible.";
                Console.Clear();
                Console.WriteLine($"ERROR: {(string.IsNullOrEmpty(argumentIdentifier) ? "" : $"(In argument {argumentIdentifier})")} {errorString}");
                Console.WriteLine();
            }

            return result;
        }

        public static bool IsDirectoryPathValid(string? path, string? argumentIdentifier = null)
        {
            bool result = Directory.Exists(path);

            if (!result)
            {
                var errorString = "The folder path is not valid or not accessible.";
                Console.Clear();
                Console.WriteLine($"ERROR: {(string.IsNullOrEmpty(argumentIdentifier) ? "" : $"(In argument {argumentIdentifier})")} {errorString}");
                Console.WriteLine();
            }

            return result;
        }
    }
}

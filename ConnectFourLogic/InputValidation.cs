namespace ConnectFour.Logic
{
    public class InputValidation
    {
        public const int k_MinDimensions = 4;
        public const int k_MaxDimensions = 8;
        private const int k_MinNumOfPlayers = 1;
        private const int k_MaxNumOfPlayers = 2;
        private const int k_AIMode = 1;
        private const string k_ExitCodeInput = "Q";

        public static bool ValidateRowsInput(string i_RawRowsInput)
        {
            return ValidateInteger(i_RawRowsInput, out int numOfRows) && ValidateInRange(numOfRows, k_MinDimensions, k_MaxDimensions);
        }

        public static bool ValidateColsInput(string i_RawColsInput)
        {
            return ValidateInteger(i_RawColsInput, out int numOfCols) && ValidateInRange(numOfCols, k_MinDimensions, k_MaxDimensions);
        }

        public static bool ValidateGameMode(string i_RawGameModeInput, out int o_GameMode)
        {
            return ValidateInteger(i_RawGameModeInput, out o_GameMode) && ValidateInRange(o_GameMode, k_MinNumOfPlayers, k_MaxNumOfPlayers);
        }

        public static bool ValidatePlayerName(string i_RawGameModeInput)
        {
            return !string.IsNullOrWhiteSpace(i_RawGameModeInput);
        }

        public static bool ValidateExitCode(string i_RawExitCodeInput)
        {
            return i_RawExitCodeInput.Equals(k_ExitCodeInput);
        }

        public static bool ValidateInteger(string i_StrInput, out int o_ParsedValue)
        {
            return int.TryParse(i_StrInput, out o_ParsedValue);
        }

        public static bool ValidateInRange(int i_NumToTest, int i_LowerBound, int i_UpperBound)
        {
            return i_NumToTest >= i_LowerBound && i_NumToTest <= i_UpperBound;
        }

        public static bool ValidateAIMode(int i_GameMode)
        {
            return i_GameMode == k_AIMode;
        }
    }
}

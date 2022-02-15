namespace ConnectFour.WinFormUI
{
    class UserInterface
    {
        private readonly GameBoardForm r_GameBoardForm;

        public UserInterface()
        {
            r_GameBoardForm = new GameBoardForm();
        }

        public void Run()
        {
            r_GameBoardForm.ShowDialog();
        }
    }
}

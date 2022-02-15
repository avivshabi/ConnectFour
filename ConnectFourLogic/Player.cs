namespace ConnectFour.Logic
{
    public class Player
    {
        private readonly string r_Name;
        private readonly eToken r_Token;
        private readonly bool r_IsHuman;
        private int m_Score;

        public Player(string i_Name, eToken i_Token, bool i_IsHuman = true)
        {
            r_Name = i_Name;
            r_Token = i_Token;
            r_IsHuman = i_IsHuman;
        }

        public int Score
        {
            get
            {
                return m_Score;
            }
            set
            {
                m_Score = value;
            }
        }

        public string Name
        {
            get
            {
                return r_Name;
            }
        }

        public bool IsHuman
        {
            get
            {
                return r_IsHuman;
            }
        }

        public eToken Token
        {
            get
            {
                return r_Token;
            }
        }
    }
}

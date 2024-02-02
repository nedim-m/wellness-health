namespace wellness.Payments.Model
{
    public class Helper
    {
        private static Helper _instance;

        private int _userId;
        private int _amount;
        private int _items;

        private Helper()
        {
            
        }

        public static Helper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Helper();
                }
                return _instance;
            }
        }

        public int UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public int Items
        {
            get { return _items; }
            set { _items = value; }
        }
    }

    
}

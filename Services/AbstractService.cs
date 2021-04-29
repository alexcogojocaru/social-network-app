using DatabaseManager;

namespace Services
{
    public class AbstractService
    {
        protected static DatabaseConnector databaseConnector;

        protected AbstractService()
        {
            //databaseConnector = DatabaseConnector.GetInstance();
        }
    }
}

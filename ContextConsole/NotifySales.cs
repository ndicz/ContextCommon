using ContextCommon;
using R_APIClient;

namespace ContextConsole
{
    public class NotifySales : R_INotify<SalesStreamDTO>
    {
        public void Notify(SalesStreamDTO poEntity)
        {
            Console.WriteLine($"Sales ID {poEntity.SalesId}, Sales Name {poEntity.SalesName}");
        }
    }
}

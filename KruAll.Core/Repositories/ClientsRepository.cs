using KruAll.Core.Models;
using KruAll.Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KruAll.Core.Repositories
{
    public class ClientsRepository : KruAllBaseRepository<Client>
    {

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public List<Client> GetClients()
        {
            return base.GetAll().ToList();
        }

        public List<Client> GetClientskeine()
        {
            List<Client> lst = base.GetAll().ToList();
            lst.Insert(0, new Client { ID = 0, Client_Nr = 0, Name = "Keine" });
            return lst;
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Client GetLastInserted()
        {
            return base.GetAll().OrderByDescending(x => x.Client_Nr).FirstOrDefault();
        }
        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Client GetClientsById(long id)
        {
            return base.FindBy(cc => cc.ID == id).FirstOrDefault();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Select, true)]
        public Client GetClientsByNr(int Nr)
        {
            return base.FindBy(cc => cc.Client_Nr == Nr).FirstOrDefault();
        }


        [DataObjectMethodAttribute(DataObjectMethodType.Insert, true)]
        public void NewClient(Client client)
        {
            base.Add(client);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Update, true)]
        public void EditClient(Client client)
        {
            if (client.ID == 0) return;
            base.Edit(client);
            Save();
        }

        [DataObjectMethodAttribute(DataObjectMethodType.Delete, true)]
        public void DeleteClient(Client client)
        {
            if (client.ID == 0) return;
            var currentvehicleType = GetClientsById(client.ID);
            base.Delete(currentvehicleType);
            Save();
        }
    }
}

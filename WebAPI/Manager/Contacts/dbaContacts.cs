using DTO;
using Manager.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Contacts
{
    public class dbaContacts
    {
        SqlDbConnect con = new SqlDbConnect();

        public List<ContactDTO> selectAll()
        {
            List<ContactDTO> datas = new List<ContactDTO>();
            ContactDTO data = new ContactDTO();

            string query = @"SELECT names.firstName, names.middleName, names.lastName, indi.isMale, contacts.contactNumber, deposits.accountNumber, accountBalances.ledger
                FROM Banks.Names AS names
                INNER JOIN Clients.Individuals AS indi
                ON names.id = indi.nameId
                INNER JOIN Clients.Clients AS clients 
                ON indi.clientId = clients.id
                INNER JOIN Clients.Contacts AS  contacts 
                ON clients.id = contacts.clientId 
                INNER JOIN Deposits.Accounts AS deposits 
                ON clients.id = deposits.clientId
                INNER JOIN Deposits.AccountBalances AS accountBalances
                ON deposits.id = accountBalances.id 
                WHERE contacts.contactTypeId = 2;";
            con.SqlQuery(query);
            con.NonQueryEx();
            foreach (DataRow row in con.QueryEx().Rows)
            {
                data = new ContactDTO();
                data.firstName = row[0].ToString();
                data.middleName = row[1].ToString();
                data.lastName = row[2].ToString();
                data.isMale = Convert.ToBoolean(row[3]);
                data.contactNo = row[4].ToString();
                data.accountNumber = row[5].ToString();
                data.ledger = Convert.ToDecimal(row[6]);
                datas.Add(data);
            }
            return datas;
        }
    }
}

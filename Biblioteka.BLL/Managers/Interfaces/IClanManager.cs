using System;
using System.Collections.Generic;
using Biblioteka.Users;
using Biblioteka.Model;

namespace Biblioteka.BLL.Interfaces
{
    public interface IClanManager
    {
        IClan AddClan(IClan clan);
        IClan GetById(string id);
        List<IClan> GetClans();
        bool RemoveClan(IClan clan);
        bool RemoveClanById(string clanId);
        List<IClan> Search(Func<IClan, bool> f);
        List<IClan> Take(double monthlyFee);
        List<IClan> GetClans(string keywords);
    }
}
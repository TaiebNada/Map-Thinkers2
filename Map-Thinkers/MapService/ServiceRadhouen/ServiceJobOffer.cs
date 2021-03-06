﻿using Data.Infrastructure;
using Infrastructure;
using MapDomain.Entities;
using MapService.M;
using MyFinance.Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapService.ServiceRadhouen
{
    public class ServiceJobOffer : Service<JobOffer>,IServiceJobOffer
    {
        //MyFinanceCtx ctx = new MyFinanceCtx();
        static IDatabaseFactory dbf = new DatabaseFactory();

        //IRepositoryBase<Product> Repo = new RepositoryBase<Product>(dbf);

        //Unit Of work design pattern
        static IUnitOfWork uow = new UnitOfWork(dbf);
        public ServiceJobOffer() : base(uow)
        {

        }

        public int addJobOffer(JobOffer jobOffer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobOffer> getAllJobOffer()
        {
            throw new NotImplementedException();
        }

        public JobOffer getJobOffer(int idJobOffer)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobOffer> getJobOfferExperience(string Experience)
        {
            ServiceJobOffer svo = new ServiceJobOffer();
            IEnumerable<JobOffer> E = svo.GetMany();
            List<JobOffer> resultatEvent = new List<JobOffer>();
            foreach (JobOffer t in E)
            {
                if (t.Experience.IndexOf(Experience) >= 0)
                {
                    resultatEvent.Add(t);
                }
            }
            return resultatEvent;
        }

        public bool removeJobOffer(int idJobOffer)
        {
            throw new NotImplementedException();
        }

        public bool updateOffer(JobOffer jobOffer)
        {
            throw new NotImplementedException();
        }
    }
}

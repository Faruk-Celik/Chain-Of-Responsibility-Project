﻿using ChainOfRespProject.DAL;
using ChainOfRespProject.Models;

namespace ChainOfRespProject.ChainOfResponsibility
{
    public class Treasurer : Employee
    {
        private readonly Context _context;

        public Treasurer ( Context context )
        {
            _context = context;
        }

        public override void ProcessRequest ( CustomerProcessViewModel model )
        {
            if (model.Amount <= 80000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                
                customerProcess.Amount = model.Amount;
                customerProcess.Name = model.Name;
                customerProcess.EmployeeName = "Faruk Çelik";
                customerProcess.Description = "Wanted Price Has been payed by Cashier ";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();

                customerProcess.Amount = model.Amount;
                customerProcess.Name = model.Name;
                customerProcess.EmployeeName = "Faruk Çelik";
                customerProcess.Description = "Wanted Price Has Not been paid by Cashier's and sended by Assistant Director";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(model);
            }
        }
    }
}

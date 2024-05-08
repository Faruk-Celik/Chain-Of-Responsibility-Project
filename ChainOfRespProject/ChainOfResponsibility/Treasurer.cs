using ChainOfRespProject.DAL;
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
                customerProcess.Description = "Faruk Çelik";
                customerProcess.EmployeeName = "Wanted Price Has been payed by cashier ";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();

                customerProcess.Amount = model.Amount;
                customerProcess.Name = model.Name;
                customerProcess.Description = "Faruk Çelik";
                customerProcess.EmployeeName = "Wanted Price Has Not been paid by cashier's and sended by assistant director";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(model);
            }
        }
    }
}

using ChainOfRespProject.DAL;
using ChainOfRespProject.Models;

namespace ChainOfRespProject.ChainOfResponsibility
{
    public class AreaDirector :Employee
    {
      
            private readonly Context _context;


            public AreaDirector ( Context context )
            {
                _context = context;
            }

            public override void ProcessRequest ( CustomerProcessViewModel model )
            {
                if (model.Amount <= 350000)
                {
                    CustomerProcess customerProcess = new CustomerProcess();

                    customerProcess.Amount = model.Amount;
                    customerProcess.Name = model.Name;
                    customerProcess.EmployeeName = "Ersen Kaçar";
                    customerProcess.Description = "Wanted Price Has been payed by Area Director ";
                    _context.CustomerProcesses.Add(customerProcess);
                    _context.SaveChanges();
                }
                else if (NextApprover != null)
                {
                    CustomerProcess customerProcess = new CustomerProcess();

                    customerProcess.Amount = model.Amount;
                    customerProcess.Name = model.Name;
                    customerProcess.EmployeeName = "Ersen Kaçar";
                    customerProcess.Description = "Payment could not be made because daily payment limits were exceeded, The customer was informed";
                    _context.CustomerProcesses.Add(customerProcess);
                    _context.SaveChanges();
                }
            }
        
    }
}

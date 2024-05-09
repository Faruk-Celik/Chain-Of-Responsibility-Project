using ChainOfRespProject.DAL;
using ChainOfRespProject.Models;

namespace ChainOfRespProject.ChainOfResponsibility
{
    public class ManageAsistant : Employee
    {
        private readonly Context _context;

        public ManageAsistant ( Context context )
        {
            _context = context;
        }

        public override void ProcessRequest ( CustomerProcessViewModel model )
        {
            if (model.Amount <= 150000)
            {
                CustomerProcess customerProcess = new CustomerProcess();
                
                customerProcess.Amount = model.Amount;
                customerProcess.Name = model.Name;
                customerProcess.Description = " Wanted Price Has been payed by Assistant Director ";
                customerProcess.EmployeeName = "Elif Çalış";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else if (NextApprover != null)
            {
                CustomerProcess customerProcess = new CustomerProcess();

                customerProcess.Amount = model.Amount;
                customerProcess.Name = model.Name;
                customerProcess.Description = "Wanted Price Has Not been paid by Assistant Director's and sended by Branch manager";
                customerProcess.EmployeeName = "Elif Çalış ";
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(model);
            }
        }
    }
}

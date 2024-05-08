using ChainOfRespProject.Models;

namespace ChainOfRespProject.ChainOfResponsibility
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextApprover ( Employee superVisor )
        {
            this.NextApprover = superVisor;

        }
        public abstract void ProcessRequest ( CustomerProcessViewModel model);
    }
}

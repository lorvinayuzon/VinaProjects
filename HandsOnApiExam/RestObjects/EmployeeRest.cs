using System;

namespace DataTransferObjects
{
    public class EmployeeRest
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public void ShouldNotBeEmpty()
        {
            throw new NotImplementedException();
        }

        public object Count()
        {
            throw new NotImplementedException();
        }
    }
}

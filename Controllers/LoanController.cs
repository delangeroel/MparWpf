using MparWpf.Controllers.Context;
using MparWpf.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MparWpf.Controllers
{
    public class LoanController
    {
        public string errorString = "";
        private IList getAllLoans()
        {
            using (var context = new MyContext())
            {
                IList lst = context.Loan
                    .OrderBy(b => b.LoanId)// Toon op volgorde van naam
                    .Skip(0).Take(100)// Kun je ook weghalen, want het voegt hier niets toe. Wordt interessant bij heel veel data
                    .ToList();
                if (lst == null) lst = new ArrayList();
                return lst;
            }
        }
        public IList getCoachesPaging(int offset, int showrecords)
        {
            using (var context = new MyContext())
            {
                IList lst = context.Loan
                    .OrderBy(b => b.LoanId)
                    .Skip(offset).Take(showrecords)
                    .ToList();
                if (lst == null) lst = new ArrayList();
                return lst;
            }
        }
        public List<Loan> findAllByNaam()
        {
            using (var ctx = new MyContext())
            {
                List<Loan> lst = ctx.Loan.OrderBy(a => a.Customer.Name)
                    //.OrderBy(b => b.Naam)// Toon op volgorde van naam
                    .ToList();

                return lst;
            }
        }
        public Loan getOnNaam(string Name)
        {
            using (var context = new MyContext())
            {
                Loan loan = context.Loan
                    //.OrderBy(b => b.Naam)// Orderby is niet nodig, je wilt er maar 1 zien
                    .Where(b => b.Customer.Name.Equals(Name))
                    .FirstOrDefault();
                return loan;
            }
        }
        public Boolean Exists(int LoanId)
        {
            Loan loan = getOnId(LoanId);
            if (loan == null) return false;
            return true;
        }
        public Loan getOnId(int LoanId)
        {
            using (var context = new MyContext())
            {
                var coach = context.Loan.Find(LoanId);
                return coach;
            }
        }
        public Boolean save(Loan Loan)
        {
            if (hasErrors(Loan)) return false;

            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (Loan.LoanId == 0)
                        {
                            context.Loan.Add(Loan);
                            context.SaveChanges();
                        }
                        else
                        {
                            context.Loan.Update(Loan);
                            context.SaveChanges();
                        }
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }
        public Boolean hasErrors(Loan _selectedObject)
        {
            Boolean _hasErrors = false;
            errorString = "";

            ValidationContext context = new ValidationContext(_selectedObject, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();

            if (!Validator.TryValidateObject(_selectedObject, context, errors, true))
            {
                foreach (ValidationResult result in errors)
                {
                    errorString = errorString + result + "\n\r";
                }
                _hasErrors = true;
            }
            else
            {
                //MessageBox.Show("Validated");
                _hasErrors = false;
            }
            return _hasErrors;
            // EF YourDbContext.Entity(YourEntity).GetValidationResult();
        }
        public Boolean delete(Loan Loan)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Loan.Remove(Loan);
                        context.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
                return false;
            }
        }
        public void delete(int id)
        {
            using (var context = new MyContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        //context.Remove(context.Coach.Single(a  => a.CoachId == id));
                        context.Loan.Remove(context.Loan.Find(id));
                        //context.Coach
                        //    .Where(b => b.CoachId == id)
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
        public string getErrors()
        {
            return errorString;
        }
    }
}

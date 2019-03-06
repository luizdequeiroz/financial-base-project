using BaseProj.Company.Interfaces;
using BaseProj.Core.Entities;
using BaseProj.Core.Repository;
using BaseProj.Core.Utils;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BaseProj.Company
{
    public class LoanRule : ILoanRule
    {
        private readonly IGenericRepository<Loan> loanRepository;

        public LoanRule(IGenericRepository<Loan> genericRepository)
        {
            loanRepository = genericRepository;
        }

        public async Task<Loan> RegisterLoanAsync(Loan loan)
        {
            return await loanRepository.InsertAsync(loan);
        }

        public async Task<Loan> UpdateLoanAsync(int id, Loan loan)
        {
            var ln = await loanRepository.SelectByIDAsync(id);
            var oldState = ln.Status;
            loan.ApplyProperties(ref ln);
            if (ln.Status != oldState)
                ln.StatusDate = DateTime.Now;
            await loanRepository.UpdateAsync(ln);
            return ln;
        }

        public async Task<Loan[]> ListLoansByClientAsync(int clientId, int quantity)
        {
            var loans = await loanRepository.SelectWhereAsync(l => l.ClientId == clientId);
            if (quantity > 0) loans = loans.OrderByDescending(c => c.Id).Take(quantity);
            return loans.ToArray();
        }
    }
}

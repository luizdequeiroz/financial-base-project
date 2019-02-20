using BaseProj.Core.Entities;
using System.Threading.Tasks;

namespace BaseProj.Company.Interfaces
{
    public interface ILoanRule
    {
        Task<Loan> RegisterLoanAsync(Loan loan);
        Task<Loan[]> ListLoansByClientAsync(int clientId, int quantity);
    }
}

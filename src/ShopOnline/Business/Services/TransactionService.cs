using Data.Models;
using Data.Repositories;
using Data.Repositories.imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ITransactionService
    {
        bool Add(Transaction transaction);
        ICollection<Transaction> FindAll();
        ICollection<Transaction> FindAll(string[] includes);
        void Save();
    }
    public class TransactionService : ITransactionService
    {
        public ITransactionRepository _transactionRepository;

        public IUnitOfWork _unitOfWork;

        public TransactionService()
        {

        }
        public TransactionService(ITransactionRepository transactionRepository, IUnitOfWork unitOfWork)
        {
            this._transactionRepository = transactionRepository;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(Transaction Transaction)
        {
            var res = _transactionRepository.add(Transaction);
            return res != null;
        }

        public ICollection<Transaction> FindAll()
        {
            var Transactions = _transactionRepository.findAll();
            return Transactions;
        }

        public ICollection<Transaction> FindAll(string[] includes)
        {
            var Transactions = _transactionRepository.findAll(includes);
            return Transactions;
        }

        public void Save()
        {
            _unitOfWork.commit();
        }
    }
}

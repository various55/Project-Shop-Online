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
    public interface ILogService
    {
        ICollection<Log> FindAll();
        ICollection<Log> FindByTime(DateTime time);
        ICollection<Log> FindByCreateBy(String createby);
        bool Add(Log log);
        void Save();
    }
    public class LogService: ILogService
    {
        public ILogRepository LogRepository;
        
        public IUnitOfWork unitOfWork;

        public LogService()
        {

        }
        public LogService(ILogRepository LogRepository, IUnitOfWork unitOfWork)
        {
            this.LogRepository = LogRepository;
            this.unitOfWork = unitOfWork;
        }


        public ICollection<Log> FindAll()
        {
            return LogRepository.findAll();
        }
       
        public ICollection<Log> FindByTime(DateTime time)
        {
            // findByCondition: Tìm kiếm theo điều kiện, nhưng mà email nó k nằm trong order
            var logs = LogRepository.findByCondition(o => o.CreateAt==time);
            return logs;
        }
        public ICollection<Log> FindByCreateBy(String createby)
        {
            // findByCondition: Tìm kiếm theo điều kiện, nhưng mà email nó k nằm trong order
            var orders = LogRepository.findByCondition(o => o.CreatedBy.Equals(createby));
            return orders;
        }
        public bool Add(Log log)
        {
            var res = LogRepository.add(log);
            return res != null;
        }
      

        public void Save()
        {
            unitOfWork.commit();
        }
    }
}

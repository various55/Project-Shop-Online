using Data.Models;
using Data.Repositories.imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface ISizeService
    {
        ICollection<Size> FindAll();
        
    }
     public class SizeService: ISizeService
    {
        public ISizeRepository sizeRepository;
       
        public SizeService()
        {

        }
        public SizeService(ISizeRepository sizeRepository)
        {
            this.sizeRepository = sizeRepository;
        }
        public ICollection<Size> FindAll()
        {
            return sizeRepository.findAll();
        }
    }
}

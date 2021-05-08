using Data.Models;
using Data.Repositories.imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IColorService
    {
        ICollection<Color> FindAll();
    }
    public class ColorService: IColorService
    {
        public IColorRepository colorRepository;

        public ColorService()
        {

        }
        public ColorService(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public ICollection<Color> FindAll()
        {
            return colorRepository.findAll();
        }
    }
}

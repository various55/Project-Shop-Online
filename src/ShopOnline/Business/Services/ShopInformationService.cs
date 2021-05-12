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
        public interface IShopInformationService
        {

            ICollection<ShopInformation> FindAll();

            ShopInformation FindById(int id);

            bool Add(ShopInformation shopInformation);
            bool Remove(int id);

            bool Update(ShopInformation shopInformation);
            void Save();
        }
        public class ShopInformationService : IShopInformationService
    {
            public IShopInformationRepository ShopInformationRepository;
            public IUserRepository userRepository;

            public IUnitOfWork unitOfWork;
            public ShopInformationService()
            {

            }
            public ShopInformationService(IShopInformationRepository ShopInformationRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
            {
                this.ShopInformationRepository = ShopInformationRepository;
                this.unitOfWork = unitOfWork;
                this.userRepository = userRepository;
            }


            public ICollection<ShopInformation> FindAll()
            {
                // ?? Ban join user lam gi the, Shopinfor co user nao dau
                var x = ShopInformationRepository.findAll();
                return x;
            }
            public ShopInformation FindById(int id)
            {
                return ShopInformationRepository.findById(id);
            }


            public bool Add(ShopInformation shopInformation)
            {
                var res = ShopInformationRepository.add(shopInformation);
                return res != null;
            }
            public bool Remove(int id)
            {
                var res = ShopInformationRepository.delete(id);
                return res != null;
            }
            public bool Update(ShopInformation shopInformation)
            {
                return ShopInformationRepository.update(shopInformation);
            }

            public void Save()
            {
                unitOfWork.commit();
            }
        }
    
}

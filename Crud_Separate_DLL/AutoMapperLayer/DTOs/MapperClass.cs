using AutoMapper;
using AutoMapperLayer.DTOs;
using AutoMapperLayer.DTOs.BankAccount;
using AutoMapperLayer.DTOs.BankTransaction;
using Domain.Models;

namespace CrudAPI.Map
{
    public class MapperClass : Profile
    {
        public MapperClass()
        {
                CreateMap<BankAccountUpdateDTO, BankAccount>().ReverseMap() ;
                CreateMap<BankAccountDTO, BankAccount>().ReverseMap().ForMember(
                    des => des.AccountTypeId,
                    opt => opt.MapFrom(src=>src.AccountType.Id)
                    );

                CreateMap<PersonDTO, Person>().ReverseMap() ;
                CreateMap<BankTransactionDTO, BankTransaction>().ReverseMap().ForMember(
                    des=>des.PaymentMethodId,
                    opt=>opt.MapFrom(src=>src.PaymentMethod.Id)
                    );

                CreateMap<AccountTypeDTO,AccountType>().ReverseMap() ;
            CreateMap<PaymentMethodDTO, PaymentMethod>().ReverseMap();
            
        }
    }
}

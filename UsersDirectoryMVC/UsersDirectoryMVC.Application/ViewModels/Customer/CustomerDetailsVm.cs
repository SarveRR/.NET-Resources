using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using UsersDirectoryMVC.Application.Mapping;

namespace UsersDirectoryMVC.Application.ViewModels.Customer
{
    public class CustomerDetailsVm : IMapFrom<UsersDirectoryMVC.Domain.Model.Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NIP { get; set; }
        public string CEOFullName { get; set; }
        public CustomerContactInfoVm customerContactInfos { get; set; }
        public List<AddressForListVm> Addresses { get; set; }
        public List<ContactDetailListVm> Emails { get; set; }
        public List<ContactDetailListVm> PhoneNumbers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UsersDirectoryMVC.Domain.Model.Customer, CustomerDetailsVm>()
                .ForMember(s => s.CEOFullName, opt => opt.MapFrom(d => d.CEOFisrtName + " " + d.CEOLastName))
                .ForMember(s => s.Addresses, opt => opt.Ignore())
                .ForMember(s => s.Emails, opt => opt.Ignore())
                .ForMember(s => s.PhoneNumbers, opt => opt.Ignore());
        }
    }
}

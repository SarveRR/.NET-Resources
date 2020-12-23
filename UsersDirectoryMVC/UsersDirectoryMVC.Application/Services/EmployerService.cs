using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.Employer;
using UsersDirectoryMVC.Domain.Interfaces;
using UsersDirectoryMVC.Domain.Model;

namespace UsersDirectoryMVC.Application.Services
{
    public class EmployerService : IEmployerService
    {
        private readonly IEmployerRepository _employerRepository;
        private readonly IMapper _mapper;

        public EmployerService(IMapper mapper, IEmployerRepository employerRepository)
        {
            _mapper = mapper;
            _employerRepository = employerRepository;
        }

        public int AddEmployer(NewEmployerVm employer)
        {
            var employerVm = _mapper.Map<Employer>(employer);
            var id = _employerRepository.AddEmployer(employerVm);
            return id;
        }

        public void DeleteEmployer(int id)
        {
            _employerRepository.DeleteEmployer(id);
        }

        public ListEmployerForListVm GetAllActiveEmplyersForList(int pageSize, int pageNumber, string searchString)
        {
            var employers = _employerRepository.GetAllActiveEmployers().Where(p => p.Name.StartsWith(searchString))
                .ProjectTo<EmployerForListVm>(_mapper.ConfigurationProvider).ToList();
            var employersToShow = employers.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
            var employerList = new ListEmployerForListVm()
            {
                PageSize = pageSize,
                CurrentPage = pageNumber,
                SearchString = searchString,
                Employers = employersToShow,
                Count = employers.Count
            };
            return employerList;
        }

        public EmployerDetailsVm GetEmployerDetails(int id)
        {
            var employer = _employerRepository.GetEmployer(id);
            var employerVm = _mapper.Map<EmployerDetailsVm>(employer);

            return employerVm;
        }

        public NewEmployerVm GetEmployerForEdit(int id)
        {
            var employer = _employerRepository.GetEmployer(id);
            var employerVm = _mapper.Map<NewEmployerVm>(employer);
            return employerVm;
        }

        public void UpdateEmployer(NewEmployerVm model)
        {
            var employer = _mapper.Map<Employer>(model);
            _employerRepository.UpdateEmployer(employer);
        }
    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travellers.DataAccess.Abstract;
using Travellers.Entities.Concrete;
using Travellers.Entities.Concrete.Dtos;

namespace Travellers.Business.Abstract
{
    public interface IContactService
    {
        public IContactDal _contactDal { get; set; }
        public IMapper _mapper { get; set; }

        public Contact ContactDtoConvert(ContactDto contactDto)
        {
            return _mapper.Map<Contact>(contactDto);
        }

        async Task<ContactDto> GetContactAsync(int id)
        {
            Contact contact= await _contactDal.GetAsync(x=>x.Id == id);
            return _mapper.Map<ContactDto>(contact);
        }

        async Task<List<ContactDto>> GetListContactAsync()
        {
            List<Contact> contacts= await _contactDal.GetAllAsync();
            List<ContactDto> contactDtos = new List<ContactDto>();

            foreach (Contact contact in contacts)
            {
                ContactDto contactDto = _mapper.Map<ContactDto>(contact);
                contactDtos.Add(contactDto);
            }

            return contactDtos;
        }

        async Task<bool> AddContactAsync(ContactDto contactDto)
        {
            Contact contact = ContactDtoConvert(contactDto);
            int response= await _contactDal.AddAsync(contact);
            return response > 0;
        }

        async Task<bool> UpdateContactAsync(ContactDto contactDto)
        {
            Contact contact = ContactDtoConvert(contactDto);
            int response= await _contactDal.UpdateAsync(contact);
            return response > 0;
        }

        async Task<bool> DeleteContactAsync(ContactDto contactDto)
        {
            Contact contact = ContactDtoConvert(contactDto);
            int response= await _contactDal.DeleteAsync(contact);
            return response > 0;
        }
        


    }
}
